using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET
{
	public interface IAnafVatPayerDataLookupClientFactory
	{
		public IAnafVatPayerDataLookupClient CreateClient();
	}
}
