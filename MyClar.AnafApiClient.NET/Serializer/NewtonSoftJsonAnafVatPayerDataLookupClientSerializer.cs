using Microsoft.Extensions.Options;
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
		private const string DefaultDateFormatString = AnafApiClientDefaults.DefaultDateFormatString;

		private readonly string mDateFormatString;

		public NewtonSoftJsonAnafVatPayerDataLookupClientSerializer( IOptions<HttpClientAnafVatPayerDataLookupClientOptions> options )
		{
			if (options == null || options.Value == null)
				throw new ArgumentNullException( nameof( options ) );

			mDateFormatString = options.Value.DateFormat;
			if (string.IsNullOrWhiteSpace( mDateFormatString ))
				mDateFormatString = DefaultDateFormatString;
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
				DateFormatString = mDateFormatString
			};
		}
	}
}
