using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TvSports.Core.Entities
{
    public class Team : ParticipantBase
    {
        public Team() { }
        public Team(string fullName, string tricode, string nickname, string city)
        {
            Name = fullName;
            Tricode = tricode;
            Nickname = nickname;
            City = city;
        }

        [StringLength(3)]
        public string Tricode { get; set; }
        [StringLength(50)]
        public string Nickname { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        public Collection<AdditionalTeamInformation> AddionalTeamInformations { get; set; } = new Collection<AdditionalTeamInformation>();
    }
}
