using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgramLanguage.Commands.CreateProgramLanguage;
using Application.Features.ProgramLanguage.Commands.DeleteProgramLanguage;
using Application.Features.ProgramLanguage.Commands.UpdateProgramLanguage;
using Application.Features.ProgramLanguage.Dtos;
using Application.Features.ProgramLanguage.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.ProgramLanguage.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.ProgramLanguage, CreatedProgramLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgramLanguage, CreateProgramLanguageCommand>().ReverseMap();
            CreateMap<Domain.Entities.ProgramLanguage, UpdatedProgramLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgramLanguage, UpdateProgramLanguageCommand>().ReverseMap();
            CreateMap<Domain.Entities.ProgramLanguage, DeletedProgramLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgramLanguage, DeleteProgramLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<Domain.Entities.ProgramLanguage>, ProgramLanguageListModel>().ReverseMap();
            CreateMap<Domain.Entities.ProgramLanguage, ProgramLanguageListDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgramLanguage, ProgramLanguageGetByIdDto>().ReverseMap();

        }
    }
}
