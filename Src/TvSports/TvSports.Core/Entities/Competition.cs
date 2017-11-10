using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Competition : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Zone Zone { get; set; }
        [Required]
        public Sport Sport { get; set; }
    }
}
