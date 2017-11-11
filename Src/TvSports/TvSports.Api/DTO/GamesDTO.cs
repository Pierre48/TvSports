using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvSports.Api.DTO
{
    public class GamesDTO
    {
        public List<SportDTO> Sports { get; set; } = new List<SportDTO>();
    }
}
