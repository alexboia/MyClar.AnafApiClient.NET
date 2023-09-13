using Newtonsoft.Json;
using System;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientVatRegistrationInterval : IEquatable<AnafApiClientVatRegistrationInterval>
	{
		public bool Equals( AnafApiClientVatRegistrationInterval other )
		{
			return other != null 
				&& other.DateStart == DateStart
				&& other.DateEnd == DateEnd
				&& other.VatRegistrationYear == VatRegistrationYear
				&& string.Equals(other.VatRegistrationMessage, VatRegistrationMessage);	
		}

		public override bool Equals( object obj )
		{
			return Equals(obj as AnafApiClientVatRegistrationInterval);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine( DateStart, 
				DateEnd, 
				VatRegistrationYear, 
				VatRegistrationMessage );
		}

		[JsonProperty( "data_inceput_ScpTVA" )]
		public DateTime DateStart
		{
			get; set;
		}

		[JsonProperty( "data_sfarsit_ScpTVA" )]
		public DateTime? DateEnd
		{
			get; set;
		}

		[JsonProperty( "data_anul_imp_ScpTVA" )]
		public int? VatRegistrationYear
		{
			get;set;
		}

		[JsonProperty( "mesaj_ScpTVA" )]
		public string VatRegistrationMessage
		{
			get;set;
		}
	}
}
