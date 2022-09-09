using Domain.Entities;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, TechnologyListDto>()
              .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(m => m.ProgrammingLanguage.Name)).ReverseMap();

            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        }
    }
}
