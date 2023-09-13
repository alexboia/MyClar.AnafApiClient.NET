using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientVatPayerLookupInput
	{
		public AnafApiClientVatPayerLookupInput()
		{
			return;
		}

		public AnafApiClientVatPayerLookupInput( string vatCode, DateTime date )
		{
			VatCode = vatCode;
			Date = date;
		}

		public AnafApiClientVatPayerLookupInput( string vatCode )
			: this( vatCode, DateTime.Now )
		{
			return;
		}

		[JsonProperty( "cui" )]
		public string VatCode
		{
			get; set;
		}

		[JsonProperty( "data" )]
		public DateTime Date
		{
			get; set;
		}
	}
}
