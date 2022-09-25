using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SubProgramLanguage.Dtos;
using Application.Features.SubProgramLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Features.SubProgramLanguage.Commands.CreateSubProgramLanguage
{
    public class CreateSubProgramLanguageCommand:IRequest<CreatedSubProgramLanguageDto>
    {
        public string SubName { get; set; }
        public int ProgramLanguageId { get; set; }

        public class CreateSubProgramLanguageHandler : IRequestHandler<CreateSubProgramLanguageCommand, CreatedSubProgramLanguageDto>
        {
            private readonly ISubProgramLanguageRepository _subProgramLanguageRepository;
            private readonly IMapper _mapper;
            private readonly SubProgramLanguageBusinessRules _subProgramLanguageBusinessRules;

            public CreateSubProgramLanguageHandler(ISubProgramLanguageRepository subProgramLanguageRepository, IMapper mapper, SubProgramLanguageBusinessRules subProgramLanguageBusinessRules)
            {
                _subProgramLanguageRepository = subProgramLanguageRepository;
                _mapper = mapper;
                _subProgramLanguageBusinessRules = subProgramLanguageBusinessRules;
            }
            public async Task<CreatedSubProgramLanguageDto> Handle(CreateSubProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                await _subProgramLanguageBusinessRules.SubProgramLanguageNameCanNotBeDuplicatedWhenInserted(
                    request.SubName);
                Domain.Entities.SubProgramLanguage mappedSubProgramLanguage=_mapper.Map<Domain.Entities.SubProgramLanguage>(request);
                Domain.Entities.SubProgramLanguage createdProgramLanguage =
                    await _subProgramLanguageRepository.AddAsync(mappedSubProgramLanguage);
                CreatedSubProgramLanguageDto createdSubProgramLanguageDto =
                    _mapper.Map<CreatedSubProgramLanguageDto>(createdProgramLanguage);
                return createdSubProgramLanguageDto;
            }
        }
    }
}
