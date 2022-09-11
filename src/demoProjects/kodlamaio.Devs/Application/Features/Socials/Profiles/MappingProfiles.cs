using Application.Features.Socials.Commands.CreateSocial;
using Application.Features.Socials.Commands.DeleteSocial;
using Application.Features.Socials.Commands.UpdateSocial;
using Application.Features.Socials.Dtos;
using Application.Features.Socials.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Social, CreateSocialCommand>().ReverseMap();
            CreateMap<Social, CreatedSocialDto>().ReverseMap();

            CreateMap<Social, UpdateSocialCommand>().ReverseMap();
            CreateMap<Social, UpdatedSocialDto>().ReverseMap();

            CreateMap<Social, DeleteSocialCommand>().ReverseMap();
            CreateMap<Social, DeletedSocialDto>().ReverseMap();

            //getlistquery
            CreateMap<SocialListModel, IPaginate<Social>>().ReverseMap();
            CreateMap<Social, SocialListDto>().ReverseMap();
        }
    }
}
