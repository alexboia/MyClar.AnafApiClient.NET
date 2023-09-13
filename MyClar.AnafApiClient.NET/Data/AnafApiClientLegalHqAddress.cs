using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientLegalHqAddress : IEquatable<AnafApiClientLegalHqAddress>, IAnafApiClientHqAddress
	{
		public bool Equals( AnafApiClientLegalHqAddress other )
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
			return Equals( obj as AnafApiClientLegalHqAddress );
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

		[JsonProperty( "sdenumire_Strada" )]
		public string StreetName
		{
			get; set;
		}

		[JsonProperty( "snumar_Strada" )]
		public string StreetNumber
		{
			get; set;
		}

		[JsonProperty( "sdenumire_Localitate" )]
		public string CityName
		{
			get; set;
		}

		[JsonProperty( "scod_Localitate" )]
		public string CityCode
		{
			get; set;
		}

		[JsonProperty( "sdenumire_Judet" )]
		public string CountyName
		{
			get; set;
		}

		[JsonProperty( "scod_Judet" )]
		public string CountyCode
		{
			get; set;
		}

		[JsonProperty( "scod_JudetAuto" )]
		public string CountyLicensePlateRegistrationCode
		{
			get; set;
		}

		[JsonProperty( "stara" )]
		public string Country
		{
			get; set;
		}

		[JsonProperty( "sdetalii_Adresa" )]
		public string AddressDetails
		{
			get; set;
		}

		[JsonProperty( "scod_Postal" )]
		public string PostalCode
		{
			get; set;
		}
	}
}
