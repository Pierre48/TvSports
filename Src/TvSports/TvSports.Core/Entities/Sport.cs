using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Sport : EntityBase
    {
        [Required]
        public  string Name{ get; set; }
    }
}
