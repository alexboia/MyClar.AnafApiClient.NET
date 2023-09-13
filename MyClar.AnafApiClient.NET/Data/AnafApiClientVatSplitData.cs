using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientVatSplitData : IEquatable<AnafApiClientVatSplitData>
	{
		public bool Equals( AnafApiClientVatSplitData other )
		{
			return other != null 
				&& other.DateStart == DateStart 
				&& other.DateEnd == DateEnd 
				&& other.VatSplitStatus == VatSplitStatus;
		}

		public override bool Equals( object obj )
		{
			return Equals(obj as AnafApiClientVatSplitData);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine( DateStart, 
				DateEnd, 
				VatSplitStatus );
		}

		[JsonProperty( "dataInceputSplitTVA" )]
		public DateTime? DateStart
		{
			get; set;
		}

		[JsonProperty( "dataAnulareSplitTVA" )]
		public DateTime? DateEnd
		{
			get; set;
		}

		[JsonProperty( "statusSplitTVA" )]
		public bool VatSplitStatus
		{
			get; set;
		}
	}
}
