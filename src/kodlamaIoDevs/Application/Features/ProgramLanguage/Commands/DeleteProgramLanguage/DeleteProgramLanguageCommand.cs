using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgramLanguage.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgramLanguage.Commands.DeleteProgramLanguage
{
    public class DeleteProgramLanguageCommand:IRequest<DeletedProgramLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgramLanguageHandler:IRequestHandler<DeleteProgramLanguageCommand,DeletedProgramLanguageDto>
        {
            private readonly IProgramLanguageRepository _programLanguageRepository;
            private readonly IMapper _mapper;

            public DeleteProgramLanguageHandler(IProgramLanguageRepository programLanguageRepository, IMapper mapper)
            {
                _programLanguageRepository = programLanguageRepository;
                _mapper = mapper;
            }
            public async Task<DeletedProgramLanguageDto> Handle(DeleteProgramLanguageCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.ProgramLanguage? programLanguageDeleted = await _programLanguageRepository.GetAsync(x => x.Id == request.Id);
                Domain.Entities.ProgramLanguage deletedProgrammingLanguage = await _programLanguageRepository.DeleteAsync(programLanguageDeleted);
                DeletedProgramLanguageDto deletedProgramLanguageDto= _mapper.Map<DeletedProgramLanguageDto>(deletedProgrammingLanguage);
                return deletedProgramLanguageDto;
            }
        }
    }
}
