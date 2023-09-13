using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyClar.AnafApiClient.NET.Transport
{
	public class HttpClientAnafVatPayerDataLookupClientTransport : IAnafVatPayerDataLookupClientTransport
	{
		private const string ContentType = "application/json";

		private readonly string mEndpoint;

		private readonly IHttpClientFactory mHttpClientFactory;

		private readonly Encoding mEncoding;

		public HttpClientAnafVatPayerDataLookupClientTransport( string endpoint,
			IHttpClientFactory httpClientFactory,
			Encoding encoding )
		{
			if (string.IsNullOrWhiteSpace( endpoint ))
				throw new ArgumentNullException( nameof( endpoint ) );

			mEndpoint = endpoint;
			mHttpClientFactory = httpClientFactory
				?? throw new ArgumentNullException( nameof( httpClientFactory ) );
			mEncoding = encoding
				?? throw new ArgumentNullException( nameof( encoding ) );
		}

		public async Task<string> DoWebServiceRequestAsync( string requestBody )
		{
			using (HttpClient httpClient = mHttpClientFactory.CreateClient( HttpClientName ))
			{
				string responseBody = null;

				Uri targetEndpoint = new Uri( mEndpoint );
				HttpContent requestContent = new StringContent( requestBody,
					mEncoding,
					ContentType );

				HttpResponseMessage responseMessage = await httpClient
					.PostAsync( targetEndpoint, requestContent );

				if (responseMessage != null
					&& responseMessage.IsSuccessStatusCode
					&& responseMessage.Content != null)
					responseBody = await responseMessage.Content.ReadAsStringAsync();

				return responseBody;
			}
		}

		private string HttpClientName
			=> GetType().FullName;
	}
}
