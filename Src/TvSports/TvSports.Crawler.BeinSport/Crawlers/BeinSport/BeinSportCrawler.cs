using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;
using System.Threading.Tasks;
using TvSports.Core.Extensions;
using TvSports.Crawler.Core;
using TvSports.Crawler.Crawlers.NbaNet.Services;
using Microsoft.Extensions.Logging;

namespace TvSports.Crawler.Crawlers.NbaNet
{
    class BeinSportCrawler : CrawlerBase
    {

        private readonly ITeamService _teamService;
        private readonly IBeinSportService _beinSportService;
        private readonly ICompetitionService _competitionService;
        private readonly ICompetitionInstanceService _competitionInstanceService;
        private readonly ICompetitionInstanceParticipantService _competitionInstanceParticipantService;
        private readonly IGameService _gameService;
        private string _season = "";
        private CompetitionInstance _nba;

        public BeinSportCrawler(
            ILoggerFactory loggerFactory,
            IBeinSportService beinSportService,
            ITeamService teamService,
            ICompetitionService competitionService,
            ICompetitionInstanceService competitionInstanceService,
            ICompetitionInstanceParticipantService competitionInstanceParticipantService,
            IGameService gameService
            ) : base(loggerFactory.CreateLogger<BeinSportCrawler>())
        {
            _teamService = teamService;
            _beinSportService = beinSportService;
            _competitionService = competitionService;
            _competitionInstanceService = competitionInstanceService;
            _competitionInstanceParticipantService = competitionInstanceParticipantService;
            _gameService = gameService;
        }

        protected override void StartingAsync()
        {
        }

        protected override void Stopping()
        {
        }
    }
}
