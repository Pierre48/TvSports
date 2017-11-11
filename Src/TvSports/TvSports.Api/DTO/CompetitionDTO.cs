using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvSports.Api.DTO
{
    public class CompetitionDTO
    {
        public List<GameDTO> Games { get; set; } = new List<GameDTO>();
        public string Name { get; internal set; }
    }
}
