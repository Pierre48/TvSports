using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;

namespace TvSports.Core.Services
{
    public class CompetitionService : ServiceBase<Competition>, ICompetitionService
    {
        private readonly IZoneService _zoneService;
        private readonly ISportService _sportService;

        public CompetitionService(
            IRepository<Competition> competitionRepository,
            IZoneService zoneService,
            ISportService sportService
            ) : base(competitionRepository)
        {
            _zoneService = zoneService;
            _sportService = sportService;
        }

        public Competition CreateAndGet(string competitionName, string sportName, string zone1, string zone2)
        {
            var zoneEntity = _zoneService.CreateOrUpdate<Zone>(new Zone(zone2, new Zone(zone1)), t=>t.Name == zone2);
            var sportEntity = _sportService.CreateOrUpdate<Zone>(new Sport(sportName), t=>t.Name == sportName);

            return CreateOrUpdate<Competition>(new Competition("NBA", sportEntity.Id,zoneEntity.Id),t=>t.Name=="NBA");
        }

        protected override void Map(Competition entity, Competition entityDb)
        {
            entityDb.Name = entity.Name;
        }
    }
}
