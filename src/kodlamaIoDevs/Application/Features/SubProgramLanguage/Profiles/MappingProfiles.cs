using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SubProgramLanguage.Commands.CreateSubProgramLanguage;
using Application.Features.SubProgramLanguage.Commands.DeleteSubProgramLanguage;
using Application.Features.SubProgramLanguage.Commands.UpdateSubProgramLanguage;
using Application.Features.SubProgramLanguage.Dtos;
using Application.Features.SubProgramLanguage.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.SubSubProgramLanguage.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.SubProgramLanguage, CreatedSubProgramLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.SubProgramLanguage, CreateSubProgramLanguageCommand>().ReverseMap();
            CreateMap<Domain.Entities.SubProgramLanguage, UpdatedSubProgramLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.SubProgramLanguage, UpdateSubProgramLanguageCommand>().ReverseMap();
            CreateMap<Domain.Entities.SubProgramLanguage, DeletedSubProgramLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.SubProgramLanguage, DeleteSubProgramLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<Domain.Entities.SubProgramLanguage>, SubProgramLanguageListModel>().ReverseMap();
            CreateMap<Domain.Entities.SubProgramLanguage, SubProgramLanguageListDto>().ReverseMap();
            CreateMap<Domain.Entities.SubProgramLanguage, SubProgramLanguageGetByIdDto>().ReverseMap();

        }
    }
}
