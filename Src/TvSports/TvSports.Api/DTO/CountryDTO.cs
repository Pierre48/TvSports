using System.Collections.Generic;
using TvSports.Core.Entities;

namespace TvSports.Api.DTO
{
    public class ZoneDTO
    {
        public List<CompetitionDTO> Competitions { get; set; } = new List<CompetitionDTO>();
        public string Name { get; internal set; }
    }
}