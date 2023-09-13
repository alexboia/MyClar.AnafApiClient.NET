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
			return new DefaultAnafVatPayerDataLookupClient(
				new NewtonSoftJsonAnafVatPayerDataLookupClientSerializer(),
				new HttpClientAnafVatPayerDataLookupClientTransport( AnafApiClientUrls.V8Url,
					mHttpClientFactory,
					Encoding.UTF8 )
			);
		}
	}
}
