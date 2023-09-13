using MyClar.AnafApiClient.NET.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET
{
	public interface IAnafVatPayerDataLookupClientSerializer
	{
		string SerializeRequestData( object requestData );

		AnafApiClientVatPayerLookupResponse DeserializeResponseData( string responseBodyJson );
	}
}
