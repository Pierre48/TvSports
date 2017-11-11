using System;
using System.Collections.Generic;
using System.Text;

namespace TvSports.Crawler.Crawlers.NbaNet.JsonObjects
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class ScoreBoard
    {
        [JsonProperty("games")]
        public Game[] Games { get; set; }

        [JsonProperty("_internal")]
        public Internal Internal { get; set; }

        [JsonProperty("numGames")]
        public long NumGames { get; set; }
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

    public partial class Game
    {
        [JsonProperty("arena")]
        public Arena Arena { get; set; }

        [JsonProperty("attendance")]
        public string Attendance { get; set; }

        [JsonProperty("clock")]
        public string Clock { get; set; }

        [JsonProperty("endTimeUTC")]
        public string EndTimeUTC { get; set; }

        [JsonProperty("extendedStatusNum")]
        public long ExtendedStatusNum { get; set; }

        [JsonProperty("gameDuration")]
        public GameDuration GameDuration { get; set; }

        [JsonProperty("gameId")]
        public string GameId { get; set; }

        [JsonProperty("hTeam")]
        public FluffyTeam HTeam { get; set; }

        [JsonProperty("hasGameBookPdf")]
        public bool HasGameBookPdf { get; set; }

        [JsonProperty("isBuzzerBeater")]
        public bool IsBuzzerBeater { get; set; }

        [JsonProperty("isGameActivated")]
        public bool IsGameActivated { get; set; }

        [JsonProperty("isPreviewArticleAvail")]
        public bool IsPreviewArticleAvail { get; set; }

        [JsonProperty("isRecapArticleAvail")]
        public bool IsRecapArticleAvail { get; set; }

        [JsonProperty("isStartTimeTBD")]
        public bool IsStartTimeTBD { get; set; }

        [JsonProperty("nugget")]
        public Nugget Nugget { get; set; }

        [JsonProperty("period")]
        public Period Period { get; set; }

        [JsonProperty("seasonStageId")]
        public long SeasonStageId { get; set; }

        [JsonProperty("seasonYear")]
        public string SeasonYear { get; set; }

        [JsonProperty("startDateEastern")]
        public string StartDateEastern { get; set; }

        [JsonProperty("startTimeEastern")]
        public string StartTimeEastern { get; set; }

        [JsonProperty("startTimeUTC")]
        public string StartTimeUTC { get; set; }

        [JsonProperty("statusNum")]
        public long StatusNum { get; set; }

        [JsonProperty("tickets")]
        public Tickets Tickets { get; set; }

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
        public DeepLink[] DeepLink { get; set; }

        [JsonProperty("isLeaguePass")]
        public bool IsLeaguePass { get; set; }

        [JsonProperty("isNationalBlackout")]
        public bool IsNationalBlackout { get; set; }

        [JsonProperty("isTNTOT")]
        public bool IsTNTOT { get; set; }

        [JsonProperty("isVR")]
        public bool IsVR { get; set; }

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

    public partial class DeepLink
    {
        [JsonProperty("androidApp")]
        public string AndroidApp { get; set; }

        [JsonProperty("broadcaster")]
        public string Broadcaster { get; set; }

        [JsonProperty("desktopWeb")]
        public string DesktopWeb { get; set; }

        [JsonProperty("iosApp")]
        public string IosApp { get; set; }

        [JsonProperty("mobileWeb")]
        public string MobileWeb { get; set; }

        [JsonProperty("regionalMarketCodes")]
        public string RegionalMarketCodes { get; set; }
    }

    public partial class Broadcasters
    {
        [JsonProperty("canadian")]
        public Broadcaster[] Canadian { get; set; }

        [JsonProperty("hTeam")]
        public Broadcaster[] HTeam { get; set; }

        [JsonProperty("national")]
        public Broadcaster[] National { get; set; }

        [JsonProperty("spanish_hTeam")]
        public object[] SpanishHTeam { get; set; }

        [JsonProperty("spanish_national")]
        public Broadcaster[] SpanishNational { get; set; }

        [JsonProperty("spanish_vTeam")]
        public Broadcaster[] SpanishVTeam { get; set; }

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

    public partial class Tickets
    {
        [JsonProperty("desktopWeb")]
        public string DesktopWeb { get; set; }

        [JsonProperty("mobileApp")]
        public string MobileApp { get; set; }

        [JsonProperty("mobileWeb")]
        public string MobileWeb { get; set; }
    }

    public partial class Period
    {
        [JsonProperty("current")]
        public long Current { get; set; }

        [JsonProperty("isEndOfPeriod")]
        public bool IsEndOfPeriod { get; set; }

        [JsonProperty("isHalftime")]
        public bool IsHalftime { get; set; }

        [JsonProperty("maxRegular")]
        public long MaxRegular { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public partial class Nugget
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class FluffyTeam
    {
        [JsonProperty("linescore")]
        public Linescore[] Linescore { get; set; }

        [JsonProperty("loss")]
        public string Loss { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("seriesLoss")]
        public string SeriesLoss { get; set; }

        [JsonProperty("seriesWin")]
        public string SeriesWin { get; set; }

        [JsonProperty("teamId")]
        public string TeamId { get; set; }

        [JsonProperty("triCode")]
        public string TriCode { get; set; }

        [JsonProperty("win")]
        public string Win { get; set; }
    }

    public partial class Linescore
    {
        [JsonProperty("score")]
        public string Score { get; set; }
    }

    public partial class GameDuration
    {
        [JsonProperty("hours")]
        public string Hours { get; set; }

        [JsonProperty("minutes")]
        public string Minutes { get; set; }
    }

    public partial class Arena
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("isDomestic")]
        public bool IsDomestic { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stateAbbr")]
        public string StateAbbr { get; set; }
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

