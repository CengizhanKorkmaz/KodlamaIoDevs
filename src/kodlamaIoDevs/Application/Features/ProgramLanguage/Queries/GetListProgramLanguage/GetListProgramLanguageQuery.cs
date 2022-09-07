using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgramLanguage.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProgramLanguage.Queries.GetListProgramLanguage
{
    public class GetListProgramLanguageQuery:IRequest<ProgramLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgramLanguageQueryHandler : IRequestHandler<GetListProgramLanguageQuery, ProgramLanguageListModel>
        {
            private readonly IProgramLanguageRepository _programLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgramLanguageQueryHandler(IProgramLanguageRepository programLanguageRepository, IMapper mapper)
            {
                _programLanguageRepository = programLanguageRepository;
                _mapper = mapper;
            }
            public async Task<ProgramLanguageListModel> Handle(GetListProgramLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.ProgramLanguage> programLanguages = await _programLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                ProgramLanguageListModel mappedProgramLanguageListModel= _mapper.Map<ProgramLanguageListModel>(programLanguages);
                return mappedProgramLanguageListModel;
            }
        }

    }
}
