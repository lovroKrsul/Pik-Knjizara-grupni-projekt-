using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIK_Library.Model
{
    public class Book
    {
        [JsonProperty("TITLE")]
        public Dictionary<string, string> Title { get; set; }

        [JsonProperty("AUTHOR")]
        public Dictionary<string, string> Author { get; set; }

        [JsonProperty("ISBN")]
        public Dictionary<string, string> Isbn { get; set; }

        [JsonProperty("PRICE")]
        public Dictionary<string, string> Price { get; set; }

        [JsonProperty("STOCK AVAILABILTY")]
        public Dictionary<string, string> StockAvailabilty { get; set; }

        [JsonProperty("COVER")]
        public Dictionary<string, string> Cover { get; set; }

        [JsonProperty("DESCRIPTION")]
        public Dictionary<string, List<string>> Description { get; set; }

        public partial class Pero
        {
            public static Pero FromJson(string json) => JsonConvert.DeserializeObject<Pero>(json, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    }
}
