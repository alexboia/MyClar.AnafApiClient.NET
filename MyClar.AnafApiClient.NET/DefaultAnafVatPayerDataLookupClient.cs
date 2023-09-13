using MyClar.AnafApiClient.NET.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClar.AnafApiClient.NET
{
	public class DefaultAnafVatPayerDataLookupClient : IAnafVatPayerDataLookupClient
	{
		private readonly IAnafVatPayerDataLookupClientSerializer mSerializer;

		private readonly IAnafVatPayerDataLookupClientTransport mTransport;

		public DefaultAnafVatPayerDataLookupClient( IAnafVatPayerDataLookupClientSerializer serializer,
			IAnafVatPayerDataLookupClientTransport transport )
		{
			mSerializer = serializer
				?? throw new ArgumentNullException( nameof( serializer ) );
			mTransport = transport
				?? throw new ArgumentNullException( nameof( transport ) );
		}

		public async Task<AnafApiClientVatPayerLookupResponse> LookupVatPayerDataAsync( AnafApiClientVatPayerLookupInput input )
		{
			if (input == null)
				throw new ArgumentNullException( nameof( input ) );

			List<AnafApiClientVatPayerLookupInput> inputList =
				new List<AnafApiClientVatPayerLookupInput>();
			inputList.Add( input );

			return await LookupVatPayerDataAsync( inputList );
		}

		public async Task<AnafApiClientVatPayerLookupResponse> LookupVatPayerDataAsync( IEnumerable<AnafApiClientVatPayerLookupInput> input )
		{
			if (input == null || !input.Any())
				throw new ArgumentNullException( nameof( input ) );

			string requestJson = mSerializer.SerializeRequestData( input );
			string responseBodyJson = await mTransport.DoWebServiceRequestAsync( requestJson );

			return !string.IsNullOrWhiteSpace( responseBodyJson )
				? mSerializer.DeserializeResponseData( responseBodyJson )
				: null;
		}
	}
}
