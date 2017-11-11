using EnsureThat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Crawler.Crawlers.NbaNet.JsonObjects.Teams;

namespace TvSports.Crawler.Crawlers.NbaNet.Adapters
{
    static class TeamAdapter
    {
        public static Team FromJson(Standard teamJson)
        {
            EnsureArg.IsNotNull(teamJson);
            var team = new Team(teamJson.FullName, teamJson.Tricode, teamJson.Nickname, teamJson.City)
            {
                AddionalTeamInformations = new Collection<AdditionalTeamInformation>
            {
                new AdditionalTeamInformation("isNBAFranchise",teamJson.IsNBAFranchise.ToString()),
                new AdditionalTeamInformation("isAllStar",teamJson.IsAllStar.ToString()),
                new AdditionalTeamInformation("altCityName",teamJson.AltCityName.ToString()),
                new AdditionalTeamInformation("confName",teamJson.ConfName.ToString()),
                new AdditionalTeamInformation("divName",teamJson.DivName.ToString()),
            }
            };
            return team;
        }
    }
}
