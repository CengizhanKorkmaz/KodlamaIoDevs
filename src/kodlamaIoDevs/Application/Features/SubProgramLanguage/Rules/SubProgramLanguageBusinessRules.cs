using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

namespace Application.Features.SubProgramLanguage.Rules
{
    public class SubProgramLanguageBusinessRules
    {
        private ISubProgramLanguageRepository _subProgramLanguageRepository;

        public SubProgramLanguageBusinessRules(ISubProgramLanguageRepository subProgramLanguageRepository)
        {
            _subProgramLanguageRepository = subProgramLanguageRepository;
        }

        public async Task SubProgramLanguageNameCanNotBeDuplicatedWhenInserted(string subName)
        {
            IPaginate<Domain.Entities.SubProgramLanguage> result =
                await _subProgramLanguageRepository.GetListAsync(p => p.SubName==subName);
            if (result.Items.Any()) throw new BusinessException("SubProgram Language name exists");
        }

        public async Task SubProgramLanugeSholudExistsWhenRequested(int id)
        {
            Domain.Entities.SubProgramLanguage? subProgramLanguage =
                await _subProgramLanguageRepository.GetAsync(b => b.Id == id);
            if (subProgramLanguage == null) throw new BusinessException("Requested subprogram language does exists");
        }
    }
}
