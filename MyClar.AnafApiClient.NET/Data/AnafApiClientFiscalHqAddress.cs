using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientFiscalHqAddress : IEquatable<AnafApiClientFiscalHqAddress>, IAnafApiClientHqAddress
	{
		public bool Equals( AnafApiClientFiscalHqAddress other )
		{
			return other != null
				&& string.Equals( StreetName, other.StreetName )
				&& string.Equals( StreetNumber, other.StreetNumber )
				&& string.Equals( CityName, other.CityName )
				&& string.Equals( CityCode, other.CityCode )
				&& string.Equals( CountyName, other.CountyName )
				&& string.Equals( CountyCode, other.CountyCode )
				&& string.Equals( CountyLicensePlateRegistrationCode, other.CountyLicensePlateRegistrationCode )
				&& string.Equals( Country, other.Country )
				&& string.Equals( AddressDetails, other.AddressDetails )
				&& string.Equals( PostalCode, other.PostalCode );
		}

		public override bool Equals( object obj )
		{
			return Equals( obj as AnafApiClientFiscalHqAddress );
		}

		public override int GetHashCode()
		{
			HashCode hash = new HashCode();
			hash.Add( StreetName );
			hash.Add( StreetNumber );
			hash.Add( CityName );
			hash.Add( CityCode );
			hash.Add( CountyName );
			hash.Add( CountyCode );
			hash.Add( CountyLicensePlateRegistrationCode );
			hash.Add( Country );
			hash.Add( AddressDetails );
			hash.Add( PostalCode );
			return hash.ToHashCode();
		}

		[JsonProperty( "ddenumire_Strada" )]
		public string StreetName
		{
			get; set;
		}

		[JsonProperty( "dnumar_Strada" )]
		public string StreetNumber
		{
			get; set;
		}

		[JsonProperty( "ddenumire_Localitate" )]
		public string CityName
		{
			get; set;
		}

		[JsonProperty( "dcod_Localitate" )]
		public string CityCode
		{
			get; set;
		}

		[JsonProperty( "ddenumire_Judet" )]
		public string CountyName
		{
			get; set;
		}

		[JsonProperty( "dcod_Judet" )]
		public string CountyCode
		{
			get; set;
		}

		[JsonProperty( "dcod_JudetAuto" )]
		public string CountyLicensePlateRegistrationCode
		{
			get; set;
		}

		[JsonProperty( "dtara" )]
		public string Country
		{
			get; set;
		}

		[JsonProperty( "ddetalii_Adresa" )]
		public string AddressDetails
		{
			get; set;
		}

		[JsonProperty( "dcod_Postal" )]
		public string PostalCode
		{
			get; set;
		}
	}
}
