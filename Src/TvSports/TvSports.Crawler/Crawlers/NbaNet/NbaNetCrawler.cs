﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;
using TvSports.Crawler.Crawlers.NbaNet.Adapters;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects;
using TeamJson = TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Teams.Standard;
using ScheduleJson = TvSports.Crawler.Crawlers.NbaNet.JsonObjects.TeamsSchedule.Standard;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.TeamsSchedule;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Teams;
using System.Threading.Tasks;
using TvSports.Crawler.Crawlers.NbaNet.Services;
using TvSports.Core.Extensions;

namespace TvSports.Crawler.Crawlers.NbaNet
{
    class NbaNetCrawler : CrawlerBase
    {

        private readonly ITeamService _teamService;
        private readonly INbaNetService _nbaNetService;
        private readonly ICompetitionService _competitionService;
        private readonly IGameService _gameService;
        private readonly Dictionary<int, TeamJson> _teams = new Dictionary<int, TeamJson>();
        private string _season = "";

        public NbaNetCrawler(
            ILoggerFactory loggerFactory,
            INbaNetService nbaNetService,
            ITeamService teamService,
            ICompetitionService competitionService,
            IGameService gameService
            ) : base(loggerFactory.CreateLogger<NbaNetCrawler>())
        {
            _teamService = teamService;
            _nbaNetService = nbaNetService;
            _competitionService = competitionService;
            _gameService = gameService;
        }

        private async Task LoadTeamsAsync()
        {
            _logger.LogInformation("Loading teams ...");
            var nba = _competitionService.CreateAndGet("NBA", "Basket", "Amerique du nord", "USA");
            var teams = await _nbaNetService.GetTeams(_season);
            teams?.League.Standard.ForEach(teamJson =>
            {
                var team = TeamAdapter.FromJson(teamJson);
                team.CompetitionId = nba.Id;
                _teamService.CreateOrUpdate<Team>(team, t => t.Name == team.Name);
                _teams[team.Id] = teamJson;
            });
        }

        private async Task LoadScheduleAsync()
        {
            _logger.LogInformation("Loading schedules ...");
            foreach (var team in _teams)
            {
                var schedule = await _nbaNetService.GetTeamSchedule(_season, team.Value.UrlName);
                schedule?.League.Standard.ForEach(gameJson =>
                {
                    var game = GameAdapter.FromJson(gameJson, _teams);
                    _gameService.CreateOrUpdate<Core.Entities.Game>(game, g =>
                         g.ParticipantAwayForeignKey == game.ParticipantAwayForeignKey &&
                         g.ParticipantHomeForeignKey == game.ParticipantHomeForeignKey &&
                         g.StartDate.Date == game.StartDate.Date);
                });
            }
        }
        private async Task LoadScoreAsync()
        {
            _logger.LogInformation("Loading results ...");
            foreach (var day in _gameService.GetPassedDayWithoutResult())
            {
                var scoreBoard = await _nbaNetService.GetScoreboard(_season, day);
                scoreBoard?.Games.ForEach(gameJson =>
                {
                    var game = GameAdapter.FromJson(gameJson, _teams);
                    _gameService.CreateOrUpdate<Core.Entities.Game>(game, g =>
                         g.ParticipantAwayForeignKey == game.ParticipantAwayForeignKey &&
                         g.ParticipantHomeForeignKey == game.ParticipantHomeForeignKey &&
                         g.StartDate.Date == game.StartDate.Date);
                });
            }
        }

        protected override void StartingAsync()
        {
            Initialize().Wait();

            LoadTeamsAsync().Wait();
            LoadScheduleAsync().Wait();
            LoadScoreAsync().Wait();
        }

        private async Task Initialize()
        {
            _logger.LogInformation("Initizing ...");
            var today = await _nbaNetService.GetCurrentSeason();
            _season = today.SeasonScheduleYear.ToString();
        }

        protected override void Stopping()
        {
        }
    }
}
