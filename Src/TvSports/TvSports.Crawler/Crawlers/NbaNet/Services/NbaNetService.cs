using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Teams;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.TeamsSchedule;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Today;

namespace TvSports.Crawler.Crawlers.NbaNet.Services
{
    internal class NbaNetService : INbaNetService
    {
        private const string BaseUrl = "http://data.nba.net/prod/v1/";

        public async Task<Today> GetCurrentSeason()
        => await Get<Today>($"{BaseUrl}today.json");

        public  async Task<Teams> GetTeams(string season)
            => await Get<Teams>($"{BaseUrl}{season}/teams.json");

        public async Task<TeamSchedule> GetTeamSchedule(string season, string team)
            => await Get<TeamSchedule>($"{BaseUrl}{season}/teams/{team}/schedule.json");

        public async Task<ScoreBoard> GetScoreboard(string season, DateTime date)
            => await Get<ScoreBoard>($"{BaseUrl}{date.ToString("yyyyMMdd")}/scoreboard.json");

        private static async Task<T> Get<T>(string url) where T:class
        {
            using (var client = new HttpClient())
            {
                var data = await client.GetAsync(url);
                var jsonResponse= await data.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(jsonResponse)) return null;
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
        }
    }
}
