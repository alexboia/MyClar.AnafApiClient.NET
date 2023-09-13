using Newtonsoft.Json;
using System;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientVatPayerData : IEquatable<AnafApiClientVatPayerData>
	{
		public bool Equals( AnafApiClientVatPayerData other )
		{
			return other != null
				&& PropertyEquals( d => d.GeneralData, other )
				&& PropertyEquals( d => d.VatRegistrationData, other )
				&& PropertyEquals( d => d.VatPaymentOnEncashmentData, other )
				&& PropertyEquals( d => d.VatSplitData, other )
				&& PropertyEquals( d => d.FiscalHqAddress, other )
				&& PropertyEquals( d => d.LegalHqAddress, other )
				&& PropertyEquals( d => d.ActiveStateData, other )
			;
		}

		private bool PropertyEquals<TProp>( Func<AnafApiClientVatPayerData, TProp> propProvider, AnafApiClientVatPayerData other )
			where TProp : class, IEquatable<TProp>
		{
			TProp v1 = propProvider.Invoke( this );
			TProp v2 = propProvider.Invoke( other );

			return (v1 != null && v2 != null && v1.Equals( v2 ))
				|| (v1 == null && v2 == null);
		}

		public override bool Equals( object obj )
		{
			return Equals( obj as AnafApiClientVatPayerData );
		}

		public override int GetHashCode()
		{
			return HashCode.Combine( GeneralData,
				VatRegistrationData,
				VatPaymentOnEncashmentData,
				VatSplitData,
				LegalHqAddress,
				FiscalHqAddress,
				ActiveStateData );
		}

		[JsonProperty( "date_generale" )]
		public AnafApiClientVatPayerGeneralData GeneralData
		{
			get; set;
		}

		[JsonProperty( "inregistrare_scop_Tva" )]
		public AnafApiClientVatRegistrationData VatRegistrationData
		{
			get; set;
		}

		[JsonProperty( "inregistrare_RTVAI" )]
		public AnafApiClientVatPaymentOnEncashmentData VatPaymentOnEncashmentData
		{
			get; set;
		}

		[JsonProperty( "inregistrare_SplitTVA" )]
		public AnafApiClientVatSplitData VatSplitData
		{
			get; set;
		}

		[JsonProperty( "adresa_sediu_social" )]
		public AnafApiClientLegalHqAddress LegalHqAddress
		{
			get; set;
		}

		[JsonProperty( "adresa_domiciliu_fiscal" )]
		public AnafApiClientFiscalHqAddress FiscalHqAddress
		{
			get; set;
		}

		[JsonProperty( "stare_inactiv" )]
		public AnafApiClientVatPayerActiveStateData ActiveStateData
		{
			get; set;
		}

		public static bool operator ==( AnafApiClientVatPayerData o1,
			AnafApiClientVatPayerData o2 )
		{
			if (o1 == null)
				return o2 == null;

			if (o2 == null)
				return false;

			if (ReferenceEquals( o1, o2 ))
				return true;

			return o1.Equals( o2 );
		}

		public static bool operator !=( AnafApiClientVatPayerData o1,
			AnafApiClientVatPayerData o2 )
		{
			if (o1 == null)
				return o2 != null;

			if (o2 == null)
				return true;

			return !o1.Equals( o2 );
		}
	}
}
