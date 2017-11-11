using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Game : EntityBase
    {
        [Required]
        [ForeignKey("ParticipantHomeForeignKey")]
        public ParticipantBase ParticipantHome { get; set; }
        [Required]
        [ForeignKey("ParticipantAwayForeignKey")]
        public ParticipantBase ParticipantAway { get; set; }
        public int? PointsHome { get; set; }
        public int? PointsAway { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public int ParticipantHomeForeignKey { get; set; }
        [Required]
        public int ParticipantAwayForeignKey { get; set; }
    }
}
