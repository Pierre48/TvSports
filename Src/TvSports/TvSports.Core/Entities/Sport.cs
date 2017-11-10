using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Sport : EntityBase
    {
        [Required]
        [StringLength(50)]
        public  string Name{ get; set; }
    }
}
