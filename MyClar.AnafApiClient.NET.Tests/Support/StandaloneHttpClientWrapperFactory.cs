using Arnath.StandaloneHttpClientFactory;
using System.Net.Http;

namespace MyClar.AnafApiClient.NET.Tests.Support
{
	public class StandaloneHttpClientWrapperFactory : IHttpClientFactory
	{
		private StandaloneHttpClientFactory mStandaloneClientFactory =
			new StandaloneHttpClientFactory();

		public HttpClient CreateClient( string name )
		{
			return mStandaloneClientFactory.CreateClient();
		}
	}
}
