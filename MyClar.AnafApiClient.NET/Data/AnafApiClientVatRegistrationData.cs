using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyClar.AnafApiClient.NET.Data
{
	public class AnafApiClientVatRegistrationData : IEquatable<AnafApiClientVatRegistrationData>
	{
		public bool Equals( AnafApiClientVatRegistrationData other )
		{
			return other != null
				&& other.IsRegistered == IsRegistered
				&& ((Intervals == null && other.Intervals == null)
					|| (Intervals != null
						&& other.Intervals != null
						&& Intervals.SequenceEqual( other.Intervals )));
		}

		public override bool Equals( object obj )
		{
			return Equals(obj as  AnafApiClientVatRegistrationData);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine( IsRegistered, 
				Intervals );
		}

		[JsonProperty( "scpTVA" )]
		public bool IsRegistered
		{
			get; set;
		}

		[JsonProperty( "perioade_TVA" )]
		public List<AnafApiClientVatRegistrationInterval> Intervals
		{
			get; set;
		}
	}
}
