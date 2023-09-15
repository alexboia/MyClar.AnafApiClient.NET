using System.Text;

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
