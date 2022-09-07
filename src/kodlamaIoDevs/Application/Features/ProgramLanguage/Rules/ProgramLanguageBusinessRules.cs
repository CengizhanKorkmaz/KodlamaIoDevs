using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgramLanguage.Rules
{
    public class ProgramLanguageBusinessRules
    {
        private IProgramLanguageRepository _programLanguageRepository;

        public ProgramLanguageBusinessRules(IProgramLanguageRepository programLanguageRepository)
        {
            _programLanguageRepository = programLanguageRepository;
        }

        public async Task ProgramLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.ProgramLanguage> result =
                await _programLanguageRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Program language name exists");
        }
      
        public async Task ProgramLanguageShouldExistsWhenRequested(int id)
        {
            Domain.Entities.ProgramLanguage? programLanguage = await _programLanguageRepository.GetAsync(b => b.Id == id);
            if (programLanguage == null) throw new BusinessException("Requested program language does exists.");
        }
    }
}
