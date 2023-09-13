using Newtonsoft.Json;
using System;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientVatPayerGeneralData : IEquatable<AnafApiClientVatPayerGeneralData>
	{
		public bool Equals( AnafApiClientVatPayerGeneralData other )
		{
			return other != null
				&& string.Equals( VatCode, other.VatCode )
				&& Date.Equals( other.Date )
				&& string.Equals( Name, other.Name )
				&& string.Equals( Address, other.Address )
				&& string.Equals( RegComNumber, other.RegComNumber )
				&& string.Equals( PhoneNumber, other.PhoneNumber )
				&& string.Equals( PostalCode, other.PostalCode )
				&& string.Equals( AuthorizationDocument, other.AuthorizationDocument )
				&& string.Equals( RegistrationState, other.RegistrationState )
				&& string.Equals( CAEN, other.CAEN )
				&& RegistrationDate.Equals( other.RegistrationDate )
				&& string.Equals( IBAN, other.IBAN )
				&& string.Equals( RelatedFiscalBody, other.RelatedFiscalBody )
				&& EInvoiceStatus == other.EInvoiceStatus
				&& string.Equals( PropertyType, other.PropertyType )
				&& string.Equals( OrganizationType, other.OrganizationType )
				&& string.Equals( LegalPersonType, other.LegalPersonType )
			;
		}

		public override bool Equals( object obj )
		{
			return Equals( obj as AnafApiClientVatPayerGeneralData );
		}

		public override int GetHashCode()
		{
			HashCode hash = new HashCode();
			hash.Add( VatCode );
			hash.Add( Date );
			hash.Add( Name );
			hash.Add( Address );
			hash.Add( RegComNumber );
			hash.Add( PhoneNumber );
			hash.Add( FaxNumber );
			hash.Add( PostalCode );
			hash.Add( AuthorizationDocument );
			hash.Add( RegistrationState );
			hash.Add( RegistrationDate );
			hash.Add( CAEN );
			hash.Add( IBAN );
			hash.Add( EInvoiceStatus );
			hash.Add( RelatedFiscalBody );
			hash.Add( PropertyType );
			hash.Add( OrganizationType );
			hash.Add( LegalPersonType );
			return hash.ToHashCode();
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

		[JsonProperty( "denumire" )]
		public string Name
		{
			get; set;
		}

		[JsonProperty( "adresa" )]
		public string Address
		{
			get; set;
		}

		[JsonProperty( "nrRegCom" )]
		public string RegComNumber
		{
			get; set;
		}

		[JsonProperty( "telefon" )]
		public string PhoneNumber
		{
			get; set;
		}

		[JsonProperty( "fax" )]
		public string FaxNumber
		{
			get; set;
		}

		[JsonProperty( "codPostal" )]
		public string PostalCode
		{
			get; set;
		}

		[JsonProperty( "act" )]
		public string AuthorizationDocument
		{
			get; set;
		}

		[JsonProperty( "stare_inregistrare" )]
		public string RegistrationState
		{
			get; set;
		}

		[JsonProperty( "data_inregistrare" )]
		public DateTime RegistrationDate
		{
			get; set;
		}

		[JsonProperty( "cod_CAEN" )]
		public string CAEN
		{
			get; set;
		}

		[JsonProperty( "iban" )]
		public string IBAN
		{
			get; set;
		}

		[JsonProperty( "statusRO_e_Factura" )]
		public bool EInvoiceStatus
		{
			get; set;
		}

		[JsonProperty( "organFiscalCompetent" )]
		public string RelatedFiscalBody
		{
			get; set;
		}

		[JsonProperty( "forma_de_proprietate" )]
		public string PropertyType
		{
			get; set;
		}

		[JsonProperty( "forma_organizare" )]
		public string OrganizationType
		{
			get; set;
		}

		[JsonProperty( "forma_juridica" )]
		public string LegalPersonType
		{
			get; set;
		}
	}
}
