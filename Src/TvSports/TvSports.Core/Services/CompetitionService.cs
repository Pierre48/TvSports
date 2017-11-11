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

        protected override void Map(Competition entity, Competition entityDb)
        {
            entityDb.Name = entity.Name;
        }
    }
}
