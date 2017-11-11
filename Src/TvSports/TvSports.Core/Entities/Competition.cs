using EnsureThat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvSports.Core.Entities
{
    [Table("Competition")]
    public class Competition : EntityBase
    {
        public Competition() { }
        public Competition(string name,int sportId, int zoneId)
        {
            EnsureArg.IsNotNullOrWhiteSpace(name);

            Name = name;
            SportForeignKey = sportId;
            ZoneForeignKey = zoneId;
        }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int SportForeignKey { get; set; }
        [Required]
        public int ZoneForeignKey { get; set; }
        [Required]
        [ForeignKey("ZoneForeignKey")]
        public Zone Zone { get; set; }
        [Required]
        [ForeignKey("SportForeignKey")]
        public Sport Sport { get; set; }
        public Collection<CompetitionInstance> CompetitionInstances { get; set; }
    }
}
