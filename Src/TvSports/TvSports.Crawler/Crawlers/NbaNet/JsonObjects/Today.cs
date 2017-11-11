using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Today
{
        public partial class Today
    {
            [JsonProperty("_internal")]
            public Internal Internal { get; set; }

            [JsonProperty("links")]
            public Dictionary<string, string> Links { get; set; }

            [JsonProperty("seasonScheduleYear")]
            public long SeasonScheduleYear { get; set; }

            [JsonProperty("showPlayoffsClinch")]
            public bool ShowPlayoffsClinch { get; set; }
        }

        public  class Internal
        {
            [JsonProperty("eventName")]
            public string EventName { get; set; }

            [JsonProperty("pubDateTime")]
            public string PubDateTime { get; set; }

            [JsonProperty("xslt")]
            public string Xslt { get; set; }
        }

        public partial class GettingStarted
        {
            public static GettingStarted FromJson(string json) => JsonConvert.DeserializeObject<GettingStarted>(json, Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this GettingStarted self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }

        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
    

}
