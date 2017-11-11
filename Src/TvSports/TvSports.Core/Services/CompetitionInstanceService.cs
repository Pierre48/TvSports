using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;

namespace TvSports.Core.Services
{
    public class CompetitionInstanceService : ServiceBase<CompetitionInstance>, ICompetitionInstanceService
    {
        private readonly IZoneService _zoneService;
        private readonly ISportService _sportService;
        private readonly ICompetitionService _competitionService;

        public CompetitionInstanceService(
            IRepository<CompetitionInstance> competitionRepository,
            IZoneService zoneService,
            ICompetitionService competitionService,
            ISportService sportService
            ) : base(competitionRepository)
        {
            _zoneService = zoneService;
            _sportService = sportService;
            _competitionService = competitionService;
        }

        public CompetitionInstance CreateAndGet(string competitionName, DateTime startDate, DateTime endDate, string sportName, string zone1, string zone2)
        {
            var zoneEntity = _zoneService.CreateOrUpdate<Zone>(new Zone(zone2, new Zone(zone1)), t => t.Name == zone2);
            var sportEntity = _sportService.CreateOrUpdate<Zone>(new Sport(sportName), t => t.Name == sportName);
            var competitionEntity = _competitionService.CreateOrUpdate<Competition>(new Competition("NBA", sportEntity.Id, zoneEntity.Id), t => t.Name == "NBA");
            string name = endDate.Year==startDate.Year? endDate.Year.ToString() : $"{startDate.Year}-{endDate.Year}";
            return CreateOrUpdate<CompetitionInstance>(new CompetitionInstance(name,startDate,endDate, competitionEntity.Id),t=>t.Name==name);
        }

        protected override void Map(CompetitionInstance entity, CompetitionInstance entityDb)
        {
            entityDb.Name = entity.Name;
            entityDb.StartDate = entity.StartDate;
            entityDb.EndDate = entity.EndDate;
        }
    }
}
