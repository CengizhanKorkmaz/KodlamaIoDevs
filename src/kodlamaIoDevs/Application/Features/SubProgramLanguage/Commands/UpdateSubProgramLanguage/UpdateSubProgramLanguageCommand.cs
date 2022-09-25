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

namespace Application.Features.SubProgramLanguage.Commands.UpdateSubProgramLanguage
{
    public class UpdateSubProgramLanguageCommand:IRequest<UpdatedSubProgramLanguageDto>
    {
        public int Id { get; set; }
        public string SubName { get; set; }
        public int ProgramLanguageId { get; set; }

        public class UpdatedSubProgramLanguageHandler : IRequestHandler<UpdateSubProgramLanguageCommand, UpdatedSubProgramLanguageDto>
        {
            private readonly ISubProgramLanguageRepository _subProgramLanguageRepository;
            private readonly IMapper _mapper;
            private readonly SubProgramLanguageBusinessRules _subProgramLanguageBusinessRules;

            public UpdatedSubProgramLanguageHandler(ISubProgramLanguageRepository subProgramLanguageRepository, IMapper mapper, SubProgramLanguageBusinessRules subProgramLanguageBusinessRules)
            {
                _subProgramLanguageRepository = subProgramLanguageRepository;
                _mapper = mapper;
                _subProgramLanguageBusinessRules = subProgramLanguageBusinessRules;
            }

            public async Task<UpdatedSubProgramLanguageDto> Handle(UpdateSubProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.SubProgramLanguage? subProgramLanguageUpdated = await _subProgramLanguageRepository.GetAsync(x => x.Id == request.Id); subProgramLanguageUpdated.SubName=request.SubName; subProgramLanguageUpdated.ProgramLanguageId= request.ProgramLanguageId;
                Domain.Entities.SubProgramLanguage updateSubProgramLanguage = await _subProgramLanguageRepository.UpdateAsync(subProgramLanguageUpdated);
                UpdatedSubProgramLanguageDto updatedSubProgramLanguageDto = _mapper.Map<UpdatedSubProgramLanguageDto>(updateSubProgramLanguage);
                return updatedSubProgramLanguageDto;
            }
        }
    }
}
