using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyClar.AnafApiClient.NET.Data
{
    public class AnafApiClientVatPayerLookupResponse
    {
        [JsonProperty("cod")]
        public int Code
        {
            get; set;
        }

        [JsonProperty("message")]
        public string Message
        {
            get; set;
        }

        [JsonProperty("found")]
        public List<AnafApiClientVatPayerData> Found
        {
            get; set;
        }

        [JsonProperty("notFound")]
        public List<string> NotFound
        {
            get; set;
        }

        [JsonIgnore]
        public bool IsSuccessful
        {
            get
            {
                return Code == 200;
            }
        }

        [JsonIgnore]
        public string RawResponse
        {
            get;set;
        }
    }
}
