using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientVatPayerActiveStateData : IEquatable<AnafApiClientVatPayerActiveStateData>
	{
		public bool Equals( AnafApiClientVatPayerActiveStateData other )
		{
			return other != null
				&& other.DateInactivated == DateInactivated
				&& other.DateReactivated == DateReactivated
				&& other.DateUpdatePublished == DateUpdatePublished
				&& other.DatePurged == DatePurged
				&& other.InactiveStatus == InactiveStatus;
		}

		public override bool Equals( object obj )
		{
			return Equals( obj as AnafApiClientVatPayerActiveStateData );
		}

		public override int GetHashCode()
		{
			return HashCode.Combine( DateInactivated, 
				DateReactivated, 
				DateUpdatePublished, 
				DatePurged, 
				InactiveStatus );
		}

		[JsonProperty( "dataInactivare" )]
		public DateTime? DateInactivated
		{
			get; set;
		}

		[JsonProperty( "dataReactivare" )]
		public DateTime? DateReactivated
		{
			get; set;
		}

		[JsonProperty( "dataPublicare" )]
		public DateTime? DateUpdatePublished
		{
			get; set;
		}

		[JsonProperty( "dataRadiere" )]
		public DateTime? DatePurged
		{
			get;set;
		}

		[JsonProperty( "statusInactivi" )]
		public bool InactiveStatus
		{
			get;set;
		}
	}
}
