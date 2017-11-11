using System;
using System.Collections.Generic;
using System.Text;

namespace TvSports.Crawler.BeinSport.Crawlers.BeinSport.HtmlObjects
{
    class ChannelHtml
    {
        public string Name { get; set; }
        public List<ProgramHtml> Programs { get; set; }
    }
}
