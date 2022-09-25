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

namespace Application.Features.ProgramLanguage.Commands.UpdateProgramLanguage
{
    public class UpdateProgramLanguageCommand:IRequest<UpdatedProgramLanguageDto>
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public class UpdateProgramLanguageHandler:IRequestHandler<UpdateProgramLanguageCommand,UpdatedProgramLanguageDto>
        {
            private readonly IProgramLanguageRepository _programLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _programLanguageBusinessRules;

            public UpdateProgramLanguageHandler(IProgramLanguageRepository programLanguageRepository, IMapper mapper, ProgramLanguageBusinessRules programLanguageBusinessRules)
            {
                _programLanguageRepository = programLanguageRepository;
                _mapper = mapper;
                _programLanguageBusinessRules = programLanguageBusinessRules;
            }
            public async Task<UpdatedProgramLanguageDto> Handle(UpdateProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.ProgramLanguage? programLanguageUpdated = await _programLanguageRepository.GetAsync(x => x.Id == request.Id); programLanguageUpdated.Name=request.Name;
                Domain.Entities.ProgramLanguage updatedProgrammingLanguage = await _programLanguageRepository.UpdateAsync(programLanguageUpdated);
                UpdatedProgramLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgramLanguageDto>(updatedProgrammingLanguage);

                return updatedProgrammingLanguageDto;

            }
        }

    }
}
