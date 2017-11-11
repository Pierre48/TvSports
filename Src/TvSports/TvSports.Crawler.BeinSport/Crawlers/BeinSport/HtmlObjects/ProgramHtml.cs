using System;
using TvSports.Core.Enums;

namespace TvSports.Crawler.BeinSport.Crawlers.BeinSport.HtmlObjects
{
    public class ProgramHtml
    {
        public string TeamAway { get; set; }
        public string TeamVisitor { get; set; }
        public string Competition { get; set; }
        public string CompetitionInstance { get; set; }
        public ProgramType ProgramType  { get;set;}
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
    }
}