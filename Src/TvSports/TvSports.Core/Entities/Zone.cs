using System;
using System.Collections.Generic;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Zone : EntityBase
    {
        public string Name { get; set; }
        public Zone Parent { get; set; }
        public ICollection<Competition> Competitions { get; set; }
        public ICollection<Zone> ChildrenZone { get; set; }
    }
}
