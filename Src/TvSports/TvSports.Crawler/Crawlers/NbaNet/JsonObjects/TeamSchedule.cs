using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TvSports.Crawler.Crawlers.NbaNet.JsonObjects.TeamsSchedule
{
    public partial class TeamSchedule
    {
        [JsonProperty("_internal")]
        public Internal Internal { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }
    }

    public partial class League
    {
        [JsonProperty("lastStandardGamePlayedIndex")]
        public long LastStandardGamePlayedIndex { get; set; }

        [JsonProperty("standard")]
        public Standard[] Standard { get; set; }
    }

    public partial class Standard
    {
        [JsonProperty("extendedStatusNum")]
        public long ExtendedStatusNum { get; set; }

        [JsonProperty("gameId")]
        public string GameId { get; set; }

        [JsonProperty("hTeam")]
        public FluffyTeam HTeam { get; set; }

        [JsonProperty("isHomeTeam")]
        public bool IsHomeTeam { get; set; }

        [JsonProperty("nugget")]
        public Nugget Nugget { get; set; }

        [JsonProperty("seasonStageId")]
        public long SeasonStageId { get; set; }

        [JsonProperty("startDateEastern")]
        public string StartDateEastern { get; set; }

        [JsonProperty("startTimeUTC")]
        public string StartTimeUTC { get; set; }

        [JsonProperty("statusNum")]
        public long StatusNum { get; set; }

        [JsonProperty("vTeam")]
        public FluffyTeam VTeam { get; set; }

        [JsonProperty("watch")]
        public Watch Watch { get; set; }
    }

    public partial class Watch
    {
        [JsonProperty("broadcast")]
        public Broadcast Broadcast { get; set; }
    }

    public partial class Broadcast
    {
        [JsonProperty("audio")]
        public Audio Audio { get; set; }

        [JsonProperty("broadcasters")]
        public Broadcasters Broadcasters { get; set; }

        [JsonProperty("video")]
        public Video Video { get; set; }
    }

    public partial class Video
    {
        [JsonProperty("canPurchase")]
        public bool CanPurchase { get; set; }

        [JsonProperty("deepLink")]
        public object[] DeepLink { get; set; }

        [JsonProperty("isLeaguePass")]
        public bool IsLeaguePass { get; set; }

        [JsonProperty("isNationalBlackout")]
        public bool IsNationalBlackout { get; set; }

        [JsonProperty("isTNTOT")]
        public bool IsTNTOT { get; set; }

        [JsonProperty("regionalBlackoutCodes")]
        public string RegionalBlackoutCodes { get; set; }

        [JsonProperty("streams")]
        public PurpleStream[] Streams { get; set; }

        [JsonProperty("tntotIsOnAir")]
        public bool TntotIsOnAir { get; set; }
    }

    public partial class PurpleStream
    {
        [JsonProperty("doesArchiveExist")]
        public bool DoesArchiveExist { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("isArchiveAvailToWatch")]
        public bool IsArchiveAvailToWatch { get; set; }

        [JsonProperty("isOnAir")]
        public bool IsOnAir { get; set; }

        [JsonProperty("streamId")]
        public string StreamId { get; set; }

        [JsonProperty("streamType")]
        public string StreamType { get; set; }
    }

    public partial class Broadcasters
    {
        [JsonProperty("canadian")]
        public Broadcaster[] Canadian { get; set; }

        [JsonProperty("hTeam")]
        public Broadcaster[] HTeam { get; set; }

        [JsonProperty("national")]
        public Broadcaster[] National { get; set; }

        [JsonProperty("spanish_national")]
        public object[] SpanishNational { get; set; }

        [JsonProperty("vTeam")]
        public Broadcaster[] VTeam { get; set; }
    }

    public partial class Audio
    {
        [JsonProperty("hTeam")]
        public PurpleTeam HTeam { get; set; }

        [JsonProperty("national")]
        public National National { get; set; }

        [JsonProperty("vTeam")]
        public PurpleTeam VTeam { get; set; }
    }

    public partial class National
    {
        [JsonProperty("broadcasters")]
        public object[] Broadcasters { get; set; }

        [JsonProperty("streams")]
        public FluffyStream[] Streams { get; set; }
    }

    public partial class PurpleTeam
    {
        [JsonProperty("broadcasters")]
        public Broadcaster[] Broadcasters { get; set; }

        [JsonProperty("streams")]
        public FluffyStream[] Streams { get; set; }
    }

    public partial class FluffyStream
    {
        [JsonProperty("isOnAir")]
        public bool IsOnAir { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("streamId")]
        public string StreamId { get; set; }
    }

    public partial class Broadcaster
    {
        [JsonProperty("longName")]
        public string LongName { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }
    }

    public partial class Nugget
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class FluffyTeam
    {
        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("teamId")]
        public string TeamId { get; set; }
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

