using Microsoft.Extensions.Options;
using MyClar.AnafApiClient.NET.Serializer;
using MyClar.AnafApiClient.NET.Transport;
using System;
using System.Net.Http;
using System.Text;

namespace MyClar.AnafApiClient.NET
{
	public class DefaultAnafVatPayerDataLookupClientFactory : IAnafVatPayerDataLookupClientFactory
	{
		private readonly IHttpClientFactory mHttpClientFactory;

		public DefaultAnafVatPayerDataLookupClientFactory( IHttpClientFactory httpClientFactory )
		{
			mHttpClientFactory = httpClientFactory
				?? throw new ArgumentNullException( nameof( httpClientFactory ) );
		}


		public IAnafVatPayerDataLookupClient CreateClient()
		{
			IOptions<HttpClientAnafVatPayerDataLookupClientOptions> options = 
				CreateOptions();

			return new DefaultAnafVatPayerDataLookupClient(
				new NewtonSoftJsonAnafVatPayerDataLookupClientSerializer( options ),
				new HttpClientAnafVatPayerDataLookupClientTransport(
					options,
					mHttpClientFactory
				)
			);
		}

		private IOptions<HttpClientAnafVatPayerDataLookupClientOptions> CreateOptions()
		{
			HttpClientAnafVatPayerDataLookupClientOptions optionsValue =
				new HttpClientAnafVatPayerDataLookupClientOptions();

			optionsValue.DateFormat = 
				AnafApiClientDefaults.DefaultDateFormatString;
			optionsValue.Endpoint =
				AnafApiClientUrls.V8Url;
			optionsValue.Encoding =
				Encoding.UTF8;

			IOptions<HttpClientAnafVatPayerDataLookupClientOptions> options =
				Options.Create( optionsValue );
			return options;
		}
	}
}
