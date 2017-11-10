﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Channel : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
