using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TvSports.Core.Interfaces;
using TvSports.Api.Adapters;
using TvSports.Api.DTO;
using System.Globalization;

namespace TvSports.Api.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("{date}")]
        public GamesDTO Get(string date,string sport =null, string zone = null)
        {
            var dt = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
            var Games = _gameService.GetGames(dt, sport, zone);
            return GameAdapter.ToDto(Games);
        }
    }
}
