using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;

namespace TvSports.Core.Services
{
    public partial class TeamService : ServiceBase<Team>,ITeamService
    {
        public TeamService(IRepository<Team> repository) : base(repository)
        {
        }


        protected override void Map(Team entity, Team entityDb)
        {
            entityDb.Name = entity.Name;
            entityDb.City = entity.City;
            entityDb.Nickname = entity.Nickname;
        }
    }
}
