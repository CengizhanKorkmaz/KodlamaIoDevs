using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SubProgramLanguage.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubProgramLanguage.Commands.DeleteSubProgramLanguage
{
    public class DeleteSubProgramLanguageCommand:IRequest<DeletedSubProgramLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteSubProgramLanguageHandler : IRequestHandler<DeleteSubProgramLanguageCommand, DeletedSubProgramLanguageDto>
        {
            private ISubProgramLanguageRepository _subProgramLanguageRepository;
            private IMapper _mapper;

            public DeleteSubProgramLanguageHandler(ISubProgramLanguageRepository subProgramLanguageRepository, IMapper mapper)
            {
                _subProgramLanguageRepository = subProgramLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSubProgramLanguageDto> Handle(DeleteSubProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.SubProgramLanguage? subProgramLanguageDeleted =
                    await _subProgramLanguageRepository.GetAsync(x => x.Id == request.Id);
                Domain.Entities.SubProgramLanguage deletedSubProgramLanguage =
                    await _subProgramLanguageRepository.DeleteAsync(subProgramLanguageDeleted);
                DeletedSubProgramLanguageDto deletedSubProgramLanguageDto =
                    _mapper.Map<DeletedSubProgramLanguageDto>(deletedSubProgramLanguage);
                return deletedSubProgramLanguageDto;
            }
        }
    }
}
