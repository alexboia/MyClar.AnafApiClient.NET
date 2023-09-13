using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyClar.AnafApiClient.NET
{
	public interface IAnafVatPayerDataLookupClientTransport
	{
		Task<string> DoWebServiceRequestAsync( string requestBody );
	}
}
