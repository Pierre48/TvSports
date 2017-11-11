using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;

namespace TvSports.Core.Interfaces
{
    public interface ICompetitionService
    {
        Competition CreateAndGet(string competitionName, string sportName, string zone1, string zone2);
    }
}
