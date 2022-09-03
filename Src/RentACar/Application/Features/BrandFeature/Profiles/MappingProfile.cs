using Application.Features.BrandFeature.Commands.CreaateBrand;
using Application.Features.BrandFeature.Dtos;
using Application.Features.BrandFeature.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BrandFeature.Profiles
{
    public   class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, CreatedBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
            CreateMap<Brand, BrandListDto>().ReverseMap();

        }
    }
}
