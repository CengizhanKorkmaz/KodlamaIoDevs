using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SubProgramLanguage.Dtos;
using Application.Features.SubProgramLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubProgramLanguage.Queries.GetByIdSubProgramLanguage
{
    public class GetByIdSubProgramLanguageQuery:IRequest<SubProgramLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdSubProgramLanguageQueryHandler : IRequestHandler<GetByIdSubProgramLanguageQuery, SubProgramLanguageGetByIdDto>
        {
            private readonly ISubProgramLanguageRepository _subProgramLanguageRepository;
            private readonly IMapper _mapper;
            private readonly SubProgramLanguageBusinessRules _subProgramLanguageBusinessRules;

            public GetByIdSubProgramLanguageQueryHandler(ISubProgramLanguageRepository subProgramLanguageRepository, IMapper mapper, SubProgramLanguageBusinessRules subProgramLanguageBusinessRules)
            {
                _subProgramLanguageRepository = subProgramLanguageRepository;
                _mapper = mapper;
                _subProgramLanguageBusinessRules = subProgramLanguageBusinessRules;
            }


            public async Task<SubProgramLanguageGetByIdDto> Handle(GetByIdSubProgramLanguageQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.SubProgramLanguage? subProgramLanguage =
                    await _subProgramLanguageRepository.GetAsync(x => x.Id == request.Id);
                _subProgramLanguageBusinessRules.SubProgramLanugeSholudExistsWhenRequested(request.Id);
                SubProgramLanguageGetByIdDto programLanguageGetByIdDto =
                    _mapper.Map<SubProgramLanguageGetByIdDto>(subProgramLanguage);
                return programLanguageGetByIdDto;
            }
        }

    }
}
