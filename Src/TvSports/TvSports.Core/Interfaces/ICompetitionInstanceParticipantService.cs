using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;

namespace TvSports.Core.Interfaces
{
    public interface ICompetitionInstanceParticipantService
    {
        CompetitionInstanceParticipant CreateOrUpdate(CompetitionInstanceParticipant competitionInstanceParticipant);
    }
}
