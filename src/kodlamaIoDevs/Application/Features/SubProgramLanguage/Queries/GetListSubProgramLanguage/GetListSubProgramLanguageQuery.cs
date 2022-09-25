using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SubProgramLanguage.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SubProgramLanguage.Queries.GetListSubProgramLanguage
{
    public class GetListSubProgramLanguageQuery:IRequest<SubProgramLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgramLanguageQueryHandler : IRequestHandler<GetListSubProgramLanguageQuery, SubProgramLanguageListModel>
        {
            private readonly ISubProgramLanguageRepository _subProgramLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgramLanguageQueryHandler(ISubProgramLanguageRepository subProgramLanguageRepository, IMapper mapper)
            {
                _subProgramLanguageRepository = subProgramLanguageRepository;
                _mapper = mapper;
            }

            public async Task<SubProgramLanguageListModel> Handle(GetListSubProgramLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.SubProgramLanguage> subProgramLanguages =
                    await _subProgramLanguageRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                SubProgramLanguageListModel mappedSubProgramLanguageListModel =
                    _mapper.Map<SubProgramLanguageListModel>(subProgramLanguages);
                return mappedSubProgramLanguageListModel;

            }
        }
    }
}
