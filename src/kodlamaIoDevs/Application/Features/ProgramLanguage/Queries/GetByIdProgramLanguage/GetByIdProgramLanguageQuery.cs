using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgramLanguage.Dtos;
using Application.Features.ProgramLanguage.Models;
using Application.Features.ProgramLanguage.Queries.GetListProgramLanguage;
using Application.Features.ProgramLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProgramLanguage.Queries.GetByIdProgramLanguage
{
    public class GetByIdProgramLanguageQuery:IRequest<ProgramLanguageGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProgramLanguageQueryHandler : IRequestHandler<GetByIdProgramLanguageQuery, ProgramLanguageGetByIdDto>
        {
            private readonly IProgramLanguageRepository _programLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramLanguageBusinessRules _businessRules;

            public GetByIdProgramLanguageQueryHandler(IProgramLanguageRepository programLanguageRepository, IMapper mapper,ProgramLanguageBusinessRules businessRules)
            {
                _programLanguageRepository = programLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<ProgramLanguageGetByIdDto> Handle(GetByIdProgramLanguageQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.ProgramLanguage? programLanguage= await _programLanguageRepository.GetAsync(p => p.Id == request.Id);
                _businessRules.ProgramLanguageShouldExistsWhenRequested(request.Id);
                ProgramLanguageGetByIdDto programLanguageGetByIdDto =
                    _mapper.Map<ProgramLanguageGetByIdDto>(programLanguage);
                return programLanguageGetByIdDto;

            }
        }
    }
}
