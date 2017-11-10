using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Match : EntityBase
    {
        [Required]
        public ParticipantBase ParticipantHome { get; set; }
        [Required]
        public ParticipantBase ParticipantAway { get; set; }
        public int? PointsHome { get; set; }
        public int? PointsAxay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
