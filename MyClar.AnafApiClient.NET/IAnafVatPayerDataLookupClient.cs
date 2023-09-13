using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyClar.AnafApiClient.NET.Data;

namespace MyClar.AnafApiClient.NET
{
	public interface IAnafVatPayerDataLookupClient
	{
		Task<AnafApiClientVatPayerLookupResponse> LookupVatPayerDataAsync( AnafApiClientVatPayerLookupInput input );

		Task<AnafApiClientVatPayerLookupResponse> LookupVatPayerDataAsync( IEnumerable<AnafApiClientVatPayerLookupInput> input );
	}
}
