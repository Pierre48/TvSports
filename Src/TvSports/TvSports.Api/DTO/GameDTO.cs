using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvSports.Api.DTO
{
    public class GameDTO
    {
        public int? PointsAway { get; internal set; }
        public int? PointsHome { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public string HomeTeam { get; internal set; }
        public string VisitorTeam { get; internal set; }
    }
}
