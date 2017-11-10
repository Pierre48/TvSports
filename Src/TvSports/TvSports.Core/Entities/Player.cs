﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Player : ParticipantBase
    {
        [Required]
        [StringLength(50)]
        public string FirstName{ get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
