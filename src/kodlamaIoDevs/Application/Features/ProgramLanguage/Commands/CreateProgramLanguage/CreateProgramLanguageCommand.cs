using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgramLanguage.Dtos;
using Application.Features.ProgramLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgramLanguage.Commands.CreateProgramLanguage
{
    public class CreateProgramLanguageCommand:IRequest<CreatedProgramLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgramLanguageHandler : IRequestHandler<CreateProgramLanguageCommand, CreatedProgramLanguageDto>
        {
            private readonly IProgramLanguageRepository _programLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _programLanguageBusinessRules;

            public CreateProgramLanguageHandler(IProgramLanguageRepository programLanguageRepository, IMapper mapper, ProgramLanguageBusinessRules programLanguageBusinessRules)
            {
                _programLanguageRepository = programLanguageRepository;
                _mapper = mapper;
                _programLanguageBusinessRules = programLanguageBusinessRules;
            }

            public async Task<CreatedProgramLanguageDto> Handle(CreateProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programLanguageBusinessRules.ProgramLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                Domain.Entities.ProgramLanguage mappedProgramLanguage = _mapper.Map<Domain.Entities.ProgramLanguage>(request);
                Domain.Entities.ProgramLanguage createdProgramLanguage = await _programLanguageRepository.AddAsync(mappedProgramLanguage);
                CreatedProgramLanguageDto createdProgramLanguageDto = _mapper.Map<CreatedProgramLanguageDto>(createdProgramLanguage);
                return createdProgramLanguageDto;
            }
        }
    }
}
