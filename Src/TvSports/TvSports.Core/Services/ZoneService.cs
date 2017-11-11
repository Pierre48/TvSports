using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;

namespace TvSports.Core.Services
{
    public partial class ZoneService : ServiceBase<Zone>,IZoneService
    {
        public ZoneService(IRepository<Zone> repository) : base(repository)
        {
        }


        protected override void Map(Zone entity, Zone entityDb)
        {
            entityDb.Name = entity.Name;
        }
    }
}
