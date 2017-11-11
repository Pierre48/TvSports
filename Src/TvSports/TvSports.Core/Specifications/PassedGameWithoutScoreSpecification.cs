using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;

namespace TvSports.Core.Specifications
{
    class PassedGameWithoutScoreSpecification : SpecificationBase<Game>
    {
        public PassedGameWithoutScoreSpecification() : base(g => g.StartDate <= DateTime.Now && g.PointsHome == null)
            {}
    }
}
