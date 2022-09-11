using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //hangi yerlerin mapleniceğini belirtiyoruz..
            CreateMap<Model, ModelListDto>()
                .ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name))
                .ReverseMap();

            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
        }
    }
}
