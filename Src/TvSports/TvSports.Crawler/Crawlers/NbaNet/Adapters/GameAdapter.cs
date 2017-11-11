using EnsureThat;
using System;
using System.Collections.Generic;
using TvSports.Core.Extensions;
using TeamJson = TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Teams.Standard;
using ScheduleJson = TvSports.Crawler.Crawlers.NbaNet.JsonObjects.TeamsSchedule.Standard;
using System.Globalization;
using System.Linq;
using TvSports.Core.Entities;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Teams;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.TeamsSchedule;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects;

namespace TvSports.Crawler.Crawlers.NbaNet.Adapters
{
    class GameAdapter
    {
        internal static TvSports.Core.Entities.Game FromJson(JsonObjects.Game gameJson, Dictionary<int, TeamJson> teams )
        {
            EnsureArg.IsNotNull(gameJson);
            EnsureArg.IsNotNull(teams);
            var game = new TvSports.Core.Entities.Game();
            game.ParticipantHomeForeignKey= teams.First(t=>t.Value.TeamId==gameJson.HTeam.TeamId).Key;
            game.ParticipantAwayForeignKey = teams.First(t => t.Value.TeamId == gameJson.VTeam.TeamId).Key;
            game.StartDate = DateTime.ParseExact(gameJson.StartTimeUTC, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
            game.EndDate = game.StartDate.AddHours(1);
            return game;
        }

        internal static TvSports.Core.Entities.Game FromJson(ScheduleJson gameJson, Dictionary<int, TeamJson> teams, CompetitionInstance competition)
        {
            EnsureArg.IsNotNull(gameJson);
            EnsureArg.IsNotNull(teams);
            var game = new TvSports.Core.Entities.Game();
            game.ParticipantHomeForeignKey = teams.First(t => t.Value.TeamId == gameJson.HTeam.TeamId).Key;
            game.ParticipantAwayForeignKey = teams.First(t => t.Value.TeamId == gameJson.VTeam.TeamId).Key;
            game.StartDate = DateTime.ParseExact(gameJson.StartTimeUTC, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
            game.EndDate = game.StartDate.AddHours(1);
            game.CompetitionInstanceId = competition.Id;
            game.PointsAway = gameJson.VTeam.Score.ToNullableInt();
            game.PointsHome =gameJson.HTeam.Score.ToNullableInt();

            return game;
        }
        
    }
}
