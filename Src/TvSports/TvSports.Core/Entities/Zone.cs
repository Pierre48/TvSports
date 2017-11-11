using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Zone : EntityBase
    {
        public Zone() { }
        public Zone(string zone1, Zone parent = null)
        {
            Name = zone1;
            Parent = parent;
        }

        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int ZoneForeignKey { get; set; }
        [ForeignKey("ZoneParentForeignKey")]
        public Zone Parent { get; set; }
        public Collection<Competition> Competitions { get; set; }
        public Collection<Zone> ChildrenZone { get; set; }
    }
}
