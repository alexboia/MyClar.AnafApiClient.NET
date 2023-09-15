using Microsoft.Extensions.Options;
using MyClar.AnafApiClient.NET.Data;
using MyClar.AnafApiClient.NET.Serializer;
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
		public async Task Test_CanGetLookupData_WhenValidVatCodesGiven_OneVatCode_NonVatPayer()
		{
			DateTime now = DateTime.Now;
			IAnafVatPayerDataLookupClient client =
				GetAnafVatPayerDataApiClient();

			AnafApiClientVatPayerLookupResponse response = await client
				.LookupVatPayerDataAsync( new AnafApiClientVatPayerLookupInput( "44932197" ) );

			AssertAllEntitiesFound( response,
				"44932197" );

			AnafApiClientVatPayerData vatPayerData =
				response.Found [ 0 ];

			AssertVatPayerDataCorrect_44932197( vatPayerData,
				now );
		}

		private void AssertVatPayerDataCorrect_44932197( AnafApiClientVatPayerData vatPayerData,
			DateTime now )
		{
			AssertGeneralDataMatches( vatPayerData,
				new AnafApiClientVatPayerGeneralData()
				{
					VatCode = "44932197",
					Date = now.Date,
					Name = "MYCLAR SOFTWARE SOLUTIONS S.R.L.",
					Address = "MUNICIPIUL BUCUREŞTI, SECTOR 3, STR. LT. AUREL BOTEA, NR.1, BL.B5D, SC.1, ET.3, AP.15",
					RegComNumber = "J40/16243/2021",
					PhoneNumber = "",
					FaxNumber = "",
					PostalCode = "",
					AuthorizationDocument = "",
					RegistrationState = "INREGISTRAT din data 20.09.2021",
					RegistrationDate = new DateTime( 2021, 9, 20 ),
					CAEN = "6201",
					IBAN = "",
					EInvoiceStatus = false,
					RelatedFiscalBody = "Administraţia Sector 3 a Finanţelor Publice",
					PropertyType = "PROPR.PRIVATA-CAPITAL PRIVAT AUTOHTON",
					OrganizationType = "PERSOANA JURIDICA",
					LegalPersonType = "SOCIETATE COMERCIALĂ CU RĂSPUNDERE LIMITATĂ"
				} );

			AssertVatRegistrationDataMatches( vatPayerData,
				new AnafApiClientVatRegistrationData()
				{
					IsRegistered = false,
					Intervals = new List<AnafApiClientVatRegistrationInterval>()
				} );

			AssertVatPaymentOnEncashmentDataMatches( vatPayerData,
				new AnafApiClientVatPaymentOnEncashmentData()
				{
					DateStart = null,
					DateEnd = null,
					DateUpdated = null,
					DatePublished = null,
					Status = false,
					UpdateType = ""
				} );

			AssertActiveStateDataMatches( vatPayerData,
				new AnafApiClientVatPayerActiveStateData()
				{
					DateInactivated = null,
					DatePurged = null,
					DateReactivated = null,
					DateUpdatePublished = null,
					InactiveStatus = false
				} );

			AssertVatSplitStateDataMatches( vatPayerData,
				new AnafApiClientVatSplitData()
				{
					DateStart = null,
					DateEnd = null,
					VatSplitStatus = false
				} );

			AssertFiscalHqAddressDataMatches( vatPayerData,
				new AnafApiClientFiscalHqAddress()
				{
					AddressDetails = "",
					CityCode = "3",
					CityName = "Sector 3 Mun. Bucureşti",
					Country = "",
					CountyCode = "40",
					CountyName = "MUNICIPIUL BUCUREŞTI",
					CountyLicensePlateRegistrationCode = "B",
					PostalCode = "",
					StreetName = "Str. Lt. Aurel Botea",
					StreetNumber = "1"
				} );

			AssertLegalHqAddressDataMatches( vatPayerData,
				new AnafApiClientLegalHqAddress()
				{
					AddressDetails = "",
					CityCode = "3",
					CityName = "Sector 3 Mun. Bucureşti",
					Country = "",
					CountyCode = "40",
					CountyName = "MUNICIPIUL BUCUREŞTI",
					CountyLicensePlateRegistrationCode = "B",
					PostalCode = "",
					StreetName = "Str. Lt. Aurel Botea",
					StreetNumber = "1"
				} );
		}

		private void AssertAllEntitiesFound( AnafApiClientVatPayerLookupResponse response,
			params string [] vatCodes )
		{
			Assert.IsNotNull( response );
			Assert.IsNotNull( response.Found );
			Assert.AreEqual( vatCodes.Length, response.Found.Count );

			foreach (string vatCode in vatCodes)
			{
				AnafApiClientVatPayerData vatPayerData = response.Found.FirstOrDefault( d
					=> d.GeneralData != null
					&& d.GeneralData.VatCode == vatCode
				);

				Assert.IsNotNull( vatPayerData );
			}

			if (response.NotFound != null)
				Assert.AreEqual( 0, response.NotFound.Count );
		}

		private void AssertGeneralDataMatches( AnafApiClientVatPayerData vatPayerData,
			AnafApiClientVatPayerGeneralData expected )
		{
			if (expected != null)
			{
				Assert.NotNull( vatPayerData.GeneralData );
				Assert.AreEqual( expected, vatPayerData.GeneralData );
			}
			else
				Assert.IsNull( vatPayerData.GeneralData );
		}

		private void AssertVatRegistrationDataMatches( AnafApiClientVatPayerData vatPayerData,
			AnafApiClientVatRegistrationData expected )
		{
			if (expected != null)
			{
				Assert.NotNull( vatPayerData.VatRegistrationData );
				Assert.AreEqual( expected, vatPayerData.VatRegistrationData );
			}
			else
				Assert.IsNull( vatPayerData.VatRegistrationData );
		}

		private void AssertVatPaymentOnEncashmentDataMatches( AnafApiClientVatPayerData vatPayerData,
			AnafApiClientVatPaymentOnEncashmentData expected )
		{
			if (expected != null)
			{
				Assert.NotNull( vatPayerData.VatPaymentOnEncashmentData );
				Assert.AreEqual( expected, vatPayerData.VatPaymentOnEncashmentData );
			}
			else
				Assert.IsNull( vatPayerData.VatPaymentOnEncashmentData );
		}

		private void AssertActiveStateDataMatches( AnafApiClientVatPayerData vatPayerData,
			AnafApiClientVatPayerActiveStateData expected )
		{
			if (expected != null)
			{
				Assert.NotNull( vatPayerData.ActiveStateData );
				Assert.AreEqual( expected, vatPayerData.ActiveStateData );
			}
			else
				Assert.IsNull( vatPayerData.ActiveStateData );
		}

		private void AssertVatSplitStateDataMatches( AnafApiClientVatPayerData vatPayerData,
			AnafApiClientVatSplitData expected )
		{
			if (expected != null)
			{
				Assert.NotNull( vatPayerData.VatSplitData );
				Assert.AreEqual( expected, vatPayerData.VatSplitData );
			}
			else
				Assert.IsNull( vatPayerData.VatSplitData );
		}

		private void AssertFiscalHqAddressDataMatches( AnafApiClientVatPayerData vatPayerData,
			AnafApiClientFiscalHqAddress expected )
		{
			if (expected != null)
			{
				Assert.NotNull( vatPayerData.FiscalHqAddress );
				Assert.AreEqual( expected, vatPayerData.FiscalHqAddress );
			}
			else
				Assert.IsNull( vatPayerData.FiscalHqAddress );
		}

		private void AssertLegalHqAddressDataMatches( AnafApiClientVatPayerData vatPayerData,
			AnafApiClientLegalHqAddress expected )
		{
			if (expected != null)
			{
				Assert.NotNull( vatPayerData.LegalHqAddress );
				Assert.AreEqual( expected, vatPayerData.LegalHqAddress );
			}
			else
				Assert.IsNull( vatPayerData.LegalHqAddress );
		}

		[Test]
		public async Task Test_CanGetLookupData_WhenValidVatCodesGiven_OneVatCode_VatPayer()
		{
			DateTime now = DateTime.Now;
			IAnafVatPayerDataLookupClient client =
				GetAnafVatPayerDataApiClient();

			AnafApiClientVatPayerLookupResponse response = await client
				.LookupVatPayerDataAsync( new AnafApiClientVatPayerLookupInput( "21609147" ) );

			AssertAllEntitiesFound( response,
				"21609147" );

			AnafApiClientVatPayerData vatPayerData =
				response.Found [ 0 ];

			AssertVatPayerDataCorrect_21609147( vatPayerData,
				now );
		}

		private void AssertVatPayerDataCorrect_21609147( AnafApiClientVatPayerData vatPayerData,
			DateTime now )
		{
			AssertGeneralDataMatches( vatPayerData,
				new AnafApiClientVatPayerGeneralData()
				{
					VatCode = "21609147",
					Date = now.Date,
					Name = "SPORT X TEAM SRL",
					Address = "JUD. HUNEDOARA, MUN. DEVA, ALEEA TRANDAFIRILOR, BL.3, SC.1, AP.1",
					RegComNumber = "J20/608/2007",
					PhoneNumber = "0728285850",
					FaxNumber = "",
					PostalCode = "330007",
					AuthorizationDocument = "",
					RegistrationState = "INREGISTRAT din data 20.04.2007",
					RegistrationDate = new DateTime( 2007, 4, 23 ),
					CAEN = "4649",
					IBAN = "",
					EInvoiceStatus = false,
					RelatedFiscalBody = "Administraţia Judeţeană a Finanţelor Publice Hunedoara",
					PropertyType = "PROPR.PRIVATA-CAPITAL PRIVAT AUTOHTON",
					OrganizationType = "PERSOANA JURIDICA",
					LegalPersonType = "SOCIETATE COMERCIALĂ CU RĂSPUNDERE LIMITATĂ"
				} );

			AssertVatRegistrationDataMatches( vatPayerData,
				new AnafApiClientVatRegistrationData()
				{
					IsRegistered = true,
					Intervals = new List<AnafApiClientVatRegistrationInterval>()
					{
						new AnafApiClientVatRegistrationInterval()
						{
							DateStart = new DateTime(2007, 04, 25),
							DateEnd = null,
							VatRegistrationYear = null,
							VatRegistrationMessage = ""
						}
					}
				} );

			AssertVatPaymentOnEncashmentDataMatches( vatPayerData,
				new AnafApiClientVatPaymentOnEncashmentData()
				{
					DateStart = new DateTime( 2013, 1, 1 ),
					DateEnd = new DateTime( 2018, 12, 1 ),
					DateUpdated = new DateTime( 2018, 11, 12 ),
					DatePublished = new DateTime( 2018, 11, 13 ),
					Status = false,
					UpdateType = "Radiere"
				} );

			AssertActiveStateDataMatches( vatPayerData,
				new AnafApiClientVatPayerActiveStateData()
				{
					DateInactivated = null,
					DatePurged = null,
					DateReactivated = null,
					DateUpdatePublished = null,
					InactiveStatus = false
				} );

			AssertVatSplitStateDataMatches( vatPayerData,
				new AnafApiClientVatSplitData()
				{
					DateStart = null,
					DateEnd = null,
					VatSplitStatus = false
				} );

			AssertFiscalHqAddressDataMatches( vatPayerData,
				new AnafApiClientFiscalHqAddress()
				{
					AddressDetails = "",
					CityCode = "170",
					CityName = "Mun. Deva",
					Country = "",
					CountyCode = "20",
					CountyName = "HUNEDOARA",
					CountyLicensePlateRegistrationCode = "HD",
					PostalCode = "330007",
					StreetName = "Aleea Trandafirilor",
					StreetNumber = ""
				} );

			AssertLegalHqAddressDataMatches( vatPayerData,
				new AnafApiClientLegalHqAddress()
				{
					AddressDetails = "",
					CityCode = "170",
					CityName = "Mun. Deva",
					Country = "",
					CountyCode = "20",
					CountyName = "HUNEDOARA",
					CountyLicensePlateRegistrationCode = "HD",
					PostalCode = "330007",
					StreetName = "Aleea Trandafirilor",
					StreetNumber = ""
				} );
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

			AssertAllEntitiesFound( response,
				"44932197",
				"21609147" );

			AnafApiClientVatPayerData vatPayerData_44932197 = response.Found
				.FirstOrDefault( d => d.GeneralData.VatCode == "44932197" );

			AssertVatPayerDataCorrect_44932197( vatPayerData_44932197,
				now );

			AnafApiClientVatPayerData vatPayerData_21609147 = response.Found
				.FirstOrDefault( d => d.GeneralData.VatCode == "21609147" );

			AssertVatPayerDataCorrect_21609147( vatPayerData_21609147,
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
