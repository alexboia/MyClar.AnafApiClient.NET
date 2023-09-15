using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClar.AnafApiClient.NET
{
	public class AnafApiClientOptions
	{
		public string Endpoint
		{
			get; set;
		}

		public Encoding Encoding
		{
			get; set;
		}

		public string DateFormat
		{
			get; set;
		}
	}
}
