using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TvSports.Core.Entities
{
    public class CompetitionInstanceParticipant 
    {
        public CompetitionInstanceParticipant() { }
        public CompetitionInstanceParticipant(int competitionInstanceId, int participantId)
        {
            ParticipantId = participantId;
            CompetitionInstanceId = competitionInstanceId;
        }

        public CompetitionInstance CompetitionInstance { get; set; }
        public ParticipantBase Participant { get; set; }
        public int CompetitionInstanceId { get; set; }
        public int ParticipantId { get; set; }
    }
}
