using System.Collections.Generic;

namespace TvSports.Api.DTO
{
    public class SportDTO
    {
        public List<ZoneDTO> Zones { get; set; } = new List<ZoneDTO>();
        public string Name { get;  set; }
    }
}