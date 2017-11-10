using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvSports.Core.Entities
{
    [Table("Competition")]
    public class Competition : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [ForeignKey("ZoneFK")]
        public Zone Zone { get; set; }
        [Required]
        [ForeignKey("SportFK")]
        public Sport Sport { get; set; }
    }
}
