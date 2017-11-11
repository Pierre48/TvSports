using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvSports.Api.DTO;
using TvSports.Core.Entities;

namespace TvSports.Api.Adapters
{
    public class GameAdapter
    {
        internal static GamesDTO ToDto(IEnumerable<Game> games)
        {
            var result = new GamesDTO();

            //games.Select(g=>g.CompetitionInstance).Select(c=>c.Competition).Select(s=>S.Sport)

            foreach (var game in games)
            {
                var sport = game.CompetitionInstance.Competition.Sport;
                var sportDto = result.Sports.FirstOrDefault(s => s.Name == sport.Name);
                if (sportDto == null)
                {
                    sportDto = new SportDTO { Name = sport.Name };
                    result.Sports.Add(sportDto);
                }

                var zone = game.CompetitionInstance.Competition.Zone;
                var zoneDto = sportDto.Zones.FirstOrDefault(s => s.Name == zone.Name);
                if (zoneDto == null)
                {
                    zoneDto = new ZoneDTO { Name = zone.Name };
                    sportDto.Zones.Add(zoneDto);
                }

                var competition = game.CompetitionInstance.Competition;
                var competitionDto = zoneDto.Competitions.FirstOrDefault(s => s.Name == competition.Name);
                if (competitionDto == null)
                {
                    competitionDto = new CompetitionDTO { Name = competition.Name };
                    zoneDto.Competitions.Add(competitionDto);
                }

                competitionDto.Games.Add(new GameDTO
                {
                    HomeTeam = game.ParticipantHome.Name,
                    VisitorTeam = game.ParticipantAway.Name,
                    StartDate = game.StartDate,
                    EndDate = game.EndDate,
                    PointsAway = game.PointsAway,
                    PointsHome = game.PointsHome
                });
            }

            return result;
        }
    }
}
