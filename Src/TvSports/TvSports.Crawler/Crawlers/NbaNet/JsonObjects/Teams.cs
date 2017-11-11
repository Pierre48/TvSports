using System;
using System.Collections.Generic;
using System.Text;

namespace TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Teams
{
        using System;
        using System.Net;
        using System.Collections.Generic;

        using Newtonsoft.Json;

        public partial class Teams
        {
            [JsonProperty("_internal")]
            public Internal Internal { get; set; }

            [JsonProperty("league")]
            public League League { get; set; }
        }

        public partial class League
        {
            [JsonProperty("standard")]
            public Standard[] Standard { get; set; }
        }

        public partial class Standard
        {
            [JsonProperty("altCityName")]
            public string AltCityName { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("confName")]
            public string ConfName { get; set; }

            [JsonProperty("divName")]
            public string DivName { get; set; }

            [JsonProperty("fullName")]
            public string FullName { get; set; }

            [JsonProperty("isAllStar")]
            public bool IsAllStar { get; set; }

            [JsonProperty("isNBAFranchise")]
            public bool IsNBAFranchise { get; set; }

            [JsonProperty("nickname")]
            public string Nickname { get; set; }

            [JsonProperty("teamId")]
            public string TeamId { get; set; }

            [JsonProperty("tricode")]
            public string Tricode { get; set; }

            [JsonProperty("urlName")]
            public string UrlName { get; set; }
        }

        public partial class Internal
        {
            [JsonProperty("eventName")]
            public string EventName { get; set; }

            [JsonProperty("pubDateTime")]
            public string PubDateTime { get; set; }

            [JsonProperty("xslt")]
            public string Xslt { get; set; }
        }


}
