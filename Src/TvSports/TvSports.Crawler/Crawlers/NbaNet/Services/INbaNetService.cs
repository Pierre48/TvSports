using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Teams;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.TeamsSchedule;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Today;

namespace TvSports.Crawler.Crawlers.NbaNet.Services
{
    internal interface INbaNetService
    {
        Task<Today> GetCurrentSeason();

         Task<Teams> GetTeams(string season);

         Task<TeamSchedule> GetTeamSchedule(string season, string team);

         Task<ScoreBoard> GetScoreboard(string season, DateTime date);
    }
}
