using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;
using TvSports.Core.Services;
using TvSports.Core.Specifications;

namespace TvGames.Core.Services
{
    public partial class GameService : ServiceBase<Game>,IGameService 
    {
        public GameService(IRepository<Game> repository) : base (repository)
        {
        }

        public IEnumerable<Game> GetGames(DateTime date, string sport, string zone)
        {
            return _repository.List(new DayGameSpecification(date, sport, zone),new string[] {
            "ParticipantHome",
            "ParticipantAway",
            "CompetitionInstance",
            "CompetitionInstance.Competition",
            "CompetitionInstance.Competition.Sport",
            "CompetitionInstance.Competition.Zone" });

        }

        public IEnumerable<DateTime> GetPassedDayWithoutResult()
        {
            return _repository.List(new PassedGameWithoutScoreSpecification()).Select(g => g.StartDate.Date).Distinct();
        }

        protected override void Map(Game entity, Game entityDb)
        {
            entityDb.ParticipantAway = entity.ParticipantAway;
            entityDb.ParticipantHome = entity.ParticipantHome;
            entityDb.PointsAway = entity.PointsAway;
            entityDb.PointsHome = entity.PointsHome;
            entityDb.StartDate = entity.StartDate;
            entityDb.EndDate = entity.EndDate;
        }
    }
}
