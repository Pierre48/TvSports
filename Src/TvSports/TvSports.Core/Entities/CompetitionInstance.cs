using EnsureThat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvSports.Core.Entities
{
    [Table("CompetitionInstance")]
    public class CompetitionInstance : EntityBase
    {
        public CompetitionInstance()
        { }
        public CompetitionInstance(string name, DateTime startDate, DateTime endDate, int competitionId)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            CompetitionForeignKey = competitionId;
        }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public int CompetitionForeignKey { get; set; }
        [Required]
        [ForeignKey("CompetitionForeignKey")]
        public Competition Competition { get; set; }

        public Collection<CompetitionInstanceParticipant> CompetitionInstanceParticipants { get; set; }
    }
}
