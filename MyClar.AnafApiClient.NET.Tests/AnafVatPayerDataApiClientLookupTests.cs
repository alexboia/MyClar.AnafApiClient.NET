using Microsoft.Extensions.Options;
using MyClar.AnafApiClient.NET.Data;
using MyClar.AnafApiClient.NET.Serializer;
using MyClar.AnafApiClient.NET.Tests.Harness;
using MyClar.AnafApiClient.NET.Tests.Support;
using MyClar.AnafApiClient.NET.Transport;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClar.AnafApiClient.NET.Tests
{
	[TestFixture]
	public class AnafVatPayerDataApiClientLookupTests
	{
		[Test]
		public async Task Test_TryGetLookupData_WhenInvalidCodesGiven_ValidCodeWithPrefix()
		{
			IAnafVatPayerDataLookupClient client =
				GetAnafVatPayerDataApiClient();

			/*
			 * If a prefix is provide to a VAT code (eg. RO), 
			 * the Web service returns an HTMl response with an error message, 
			 * not a JSON response:
			 *	<html>
			 *		<head>
			 *			<title>Request Rejected</title>
			 *		</head>
			 *
			 *		<body>The requested URL was rejected. Please consult with your
			 *			administrator.<br><br>Your support ID is: 9278836106349682373<br><br><a href='javascript:history.back();'>
			 *			[Go Back]</a>
			 *		</body>
			 * 
			 *		</html>
			 */

			AnafApiClientVatPayerLookupResponse response = await client
				.LookupVatPayerDataAsync( new AnafApiClientVatPayerLookupInput( "RO44932197" ) );

			Assert.NotNull( response );
			Assert.IsFalse( response.IsSuccessful );
			Assert.AreEqual( "Invalid response received", response.Message );
			Assert.AreEqual( 501, response.Code );
		}

		[Test]
		public async Task Test_TryGetLookupData_WhenInvalidCodesGiven_NumericCodeButTooLong()
		{
			IAnafVatPayerDataLookupClient client =
				GetAnafVatPayerDataApiClient();

			AnafApiClientVatPayerLookupResponse response = await client
				.LookupVatPayerDataAsync( new AnafApiClientVatPayerLookupInput( "2160914712" ) );

			Assert.NotNull( response );
			Assert.IsFalse( response.IsSuccessful );
			Assert.AreEqual( 501, response.Code );
		}


		[Test]
		public async Task Test_CanGetLookupData_WhenValidVatCodesGiven_OneVatCode_NonVatPayer()
		{
			DateTime now = DateTime.Now;
			IAnafVatPayerDataLookupClient client =
				GetAnafVatPayerDataApiClient();

			AnafApiClientVatPayerLookupResponse response = await client
				.LookupVatPayerDataAsync( new AnafApiClientVatPayerLookupInput( "44932197" ) );

			Asserts.AssertAllEntitiesFound( response,
				"44932197" );

			AnafApiClientVatPayerData vatPayerData =
				response.Found [ 0 ];

			Asserts.AssertVatPayerDataCorrect_44932197( vatPayerData,
				now );
		}

		[Test]
		public async Task Test_CanGetLookupData_WhenValidVatCodesGiven_OneVatCode_VatPayer()
		{
			DateTime now = DateTime.Now;
			IAnafVatPayerDataLookupClient client =
				GetAnafVatPayerDataApiClient();

			AnafApiClientVatPayerLookupResponse response = await client
				.LookupVatPayerDataAsync( new AnafApiClientVatPayerLookupInput( "21609147" ) );

			Asserts.AssertAllEntitiesFound( response,
				"21609147" );

			AnafApiClientVatPayerData vatPayerData =
				response.Found [ 0 ];

			Asserts.AssertVatPayerDataCorrect_21609147( vatPayerData,
				now );
		}

		[Test]
		public async Task Test_CanGetLookupData_WhenValidVatCodesGiven_MultipleVatCodes()
		{
			DateTime now = DateTime.Now;
			IAnafVatPayerDataLookupClient client =
				GetAnafVatPayerDataApiClient();

			AnafApiClientVatPayerLookupResponse response = await client
				.LookupVatPayerDataAsync( new List<AnafApiClientVatPayerLookupInput>()
				{
					new AnafApiClientVatPayerLookupInput( "44932197" ),
					new AnafApiClientVatPayerLookupInput( "21609147")
				} );

			Asserts.AssertAllEntitiesFound( response,
				"44932197",
				"21609147" );

			AnafApiClientVatPayerData vatPayerData_44932197 = response.Found
				.FirstOrDefault( d => d.GeneralData.VatCode == "44932197" );

			Asserts.AssertVatPayerDataCorrect_44932197( vatPayerData_44932197,
				now );

			AnafApiClientVatPayerData vatPayerData_21609147 = response.Found
				.FirstOrDefault( d => d.GeneralData.VatCode == "21609147" );

			Asserts.AssertVatPayerDataCorrect_21609147( vatPayerData_21609147,
				now );
		}

		[Test]
		public async Task Test_TryGetLookupData_WhenOnlyNonExistingCodesGiven()
		{
			IAnafVatPayerDataLookupClient client =
				GetAnafVatPayerDataApiClient();

			AnafApiClientVatPayerLookupResponse response = await client
				.LookupVatPayerDataAsync( new List<AnafApiClientVatPayerLookupInput>()
				{
					new AnafApiClientVatPayerLookupInput( "449321971" ),
					new AnafApiClientVatPayerLookupInput( "216091471")
				} );

			AssertAllEntitiesNotFound( response,
				"449321971",
				"216091471" );
		}

		private void AssertAllEntitiesNotFound( AnafApiClientVatPayerLookupResponse response,
			params string [] vatCodes )
		{
			Assert.IsNotNull( response );
			Assert.IsNotNull( response.NotFound );
			Assert.AreEqual( vatCodes.Length, response.NotFound.Count );

			foreach (string vatCode in vatCodes)
			{
				Assert.IsTrue( response.NotFound.Contains( vatCode ) );
			}

			if (response.Found != null)
				Assert.AreEqual( 0, response.Found.Count );
		}

		private IAnafVatPayerDataLookupClient GetAnafVatPayerDataApiClient()
		{
			IOptions<HttpClientAnafVatPayerDataLookupClientOptions> options = 
				CreateOptions();

			return new DefaultAnafVatPayerDataLookupClient(
				new NewtonSoftJsonAnafVatPayerDataLookupClientSerializer( options ),
				new HttpClientAnafVatPayerDataLookupClientTransport( options,
					new StandaloneHttpClientWrapperFactory() )
			);
		}

		private IOptions<HttpClientAnafVatPayerDataLookupClientOptions> CreateOptions()
		{
			HttpClientAnafVatPayerDataLookupClientOptions options =
				new HttpClientAnafVatPayerDataLookupClientOptions();

			options.Endpoint = AnafApiClientUrls.V8Url;
			options.Encoding = Encoding.UTF8;

			return Options.Create( options );
		}
	}
}
