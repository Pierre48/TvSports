using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Zone : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
        public Zone Parent { get; set; }
        public ICollection<Competition> Competitions { get; set; }
        public ICollection<Zone> ChildrenZone { get; set; }
    }
}
