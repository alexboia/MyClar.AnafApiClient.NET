using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientVatPaymentOnEncashmentData : IEquatable<AnafApiClientVatPaymentOnEncashmentData>
	{
		public bool Equals( AnafApiClientVatPaymentOnEncashmentData other )
		{
			return other != null
				&& DateStart == other.DateStart
				&& DateEnd == other.DateEnd
				&& DateUpdated == other.DateUpdated
				&& DatePublished == other.DatePublished
				&& string.Equals( UpdateType, other.UpdateType )
				&& Status == other.Status;
		}

		public override bool Equals( object obj )
		{
			return Equals( obj as AnafApiClientVatPaymentOnEncashmentData );
		}

		public override int GetHashCode()
		{
			return HashCode.Combine( DateStart, 
				DateEnd, 
				DateUpdated, 
				DatePublished, 
				UpdateType, 
				Status );
		}

		[JsonProperty( "dataInceputTvaInc" )]
		public DateTime? DateStart
		{
			get;set;
		}

		[JsonProperty( "dataSfarsitTvaInc" )]
		public DateTime? DateEnd
		{
			get;set;
		}

		[JsonProperty( "dataActualizareTvaInc" )]
		public DateTime? DateUpdated
		{
			get;set;
		}

		[JsonProperty( "dataPublicareTvaInc" )]
		public DateTime? DatePublished
		{
			get;set;
		}
		
		[JsonProperty( "tipActTvaInc" )]
		public string UpdateType
		{
			get;set;
		}

		[JsonProperty( "statusTvaIncasare" )]
		public bool Status
		{
			get;set;
		}
	}
}
