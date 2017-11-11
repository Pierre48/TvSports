using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TvSports.Core.Entities;

namespace TvSports.Core.Specifications
{
    class DayGameSpecification : SpecificationBase<Game>
    {
        public DayGameSpecification(DateTime date, string sport, string zone) : 
            base(g=>g.StartDate.Date == date.Date &&
                (sport ==null || sport == g.CompetitionInstance.Competition.Sport.Name)&&
                (zone == null || zone == g.CompetitionInstance.Competition.Zone.Name))
        {
        }
    }
}
