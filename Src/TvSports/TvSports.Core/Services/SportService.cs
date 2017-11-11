using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;

namespace TvSports.Core.Services
{
    public partial class SportService : ServiceBase<Sport>,ISportService 
    {
        public SportService(IRepository<Sport> repository) : base (repository)
        {
        }

        protected override void Map(Sport entity, Sport entityDb)
        {
            entityDb.Name = entity.Name;
        }
    }
}
