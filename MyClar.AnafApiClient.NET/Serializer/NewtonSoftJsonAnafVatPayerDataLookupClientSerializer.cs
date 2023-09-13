using MyClar.AnafApiClient.NET.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET.Serializer
{
	public class NewtonSoftJsonAnafVatPayerDataLookupClientSerializer : IAnafVatPayerDataLookupClientSerializer
	{
		private const string DefaultDateFormatString = "yyyy-MM-dd";

		private readonly string mDateFormatString;

		public NewtonSoftJsonAnafVatPayerDataLookupClientSerializer( string dateFormatString = DefaultDateFormatString )
		{

			mDateFormatString = dateFormatString;
			if (string.IsNullOrWhiteSpace( dateFormatString ))
				dateFormatString = DefaultDateFormatString;
		}

		public AnafApiClientVatPayerLookupResponse DeserializeResponseData( string responseBodyJson )
		{
			if (string.IsNullOrWhiteSpace( responseBodyJson ))
				return null;

			return JsonConvert.DeserializeObject<AnafApiClientVatPayerLookupResponse>( responseBodyJson,
				GetSettings() );
		}

		public string SerializeRequestData( object requestData )
		{
			return JsonConvert.SerializeObject( requestData,
				GetSettings() );
		}

		private JsonSerializerSettings GetSettings()
		{
			return new JsonSerializerSettings()
			{
				DateFormatString = "yyyy-MM-dd"
			};
		}
	}
}
