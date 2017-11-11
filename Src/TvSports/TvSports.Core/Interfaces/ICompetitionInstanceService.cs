using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;

namespace TvSports.Core.Interfaces
{
    public interface ICompetitionInstanceService
    {
        CompetitionInstance CreateAndGet(string competitionName, DateTime startDate, DateTime endDate, string sportName, string zone1, string zone2);
    }
}
