using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;

namespace TvSports.Core.Services
{
    public class CompetitionInstanceParticipantService : ICompetitionInstanceParticipantService
    {
        private ICommonRepository<CompetitionInstanceParticipant> _repository;

        public CompetitionInstanceParticipantService(
            ICommonRepository<CompetitionInstanceParticipant> repository)
        {
            _repository = repository;
        }
        public CompetitionInstanceParticipant CreateOrUpdate(CompetitionInstanceParticipant competitionInstanceParticipant)
        {
            var existing = _repository.GetSingleByFilter(x =>
                x.CompetitionInstanceId == competitionInstanceParticipant.CompetitionInstanceId &&
                x.ParticipantId == competitionInstanceParticipant.ParticipantId);
            if (existing == null)
            {
                _repository.Add(competitionInstanceParticipant);
                return competitionInstanceParticipant;
            }
            else
            {
                Map(competitionInstanceParticipant, existing);
                _repository.Update(existing);
                return existing;
            }
        }

        private void Map(CompetitionInstanceParticipant competitionInstanceParticipant, CompetitionInstanceParticipant existing)
        {
        }
    }
}
