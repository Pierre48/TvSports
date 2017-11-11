﻿namespace TvSports.Core.Entities
{
    public class AdditionalTeamInformation : EntityBase
    {
        public AdditionalTeamInformation(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}