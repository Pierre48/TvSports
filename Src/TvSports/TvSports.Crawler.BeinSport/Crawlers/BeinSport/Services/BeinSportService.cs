using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TvSports.Crawler.Crawlers.NbaNet.Services
{
    internal class BeinSportService : IBeinSportService
    {
        /// <summary>
        /// http://epg.beinsports.com/utctime.php?cdate=2017-11-15&offset=+1&mins=00&category=sports
        /// </summary>
        private const string BaseUrl = "http://epg.beinsports.com/utctime.php?cdate={0}&offset=+1&mins=00&category=sports";

//        public async Task<Today> GetCurrentSeason()
//        => await Get<Today>($"{BaseUrl}today.json");

//        public  async Task<Teams> GetTeams(string season)
//            => await Get<Teams>($"{BaseUrl}{season}/teams.json");

//        public async Task<TeamSchedule> GetTeamSchedule(string season, string team)
//            => await Get<TeamSchedule>($"{BaseUrl}{season}/teams/{team}/schedule.json");

//        public async Task<ScoreBoard> GetScoreboard(string season, DateTime date)
//            => await Get<ScoreBoard>($"{BaseUrl}{date.ToString("yyyyMMdd")}/scoreboard.json");

//        private static async Task<T> Get<T>(string url) where T:class
//        {
//            using (var client = new HttpClient())
//            {
//                var data = await client.GetAsync(url);
//                var jsonResponse= await data.Content.ReadAsStringAsync();
//                if (string.IsNullOrWhiteSpace(jsonResponse)) return null;
//                return JsonConvert.DeserializeObject<T>(jsonResponse);
//            }
//        }
    }
}
