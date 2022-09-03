using Application.Features.BrandFeature.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BrandFeature.Queries.GetListBrand
{
    public class GetListBrandQuery : IRequest<BrandListModel> //Sayfalama bilgisini encapsülasiyon yapmak adına ve sayfalama yapıcağımız için dto yerine model kullandım.
    {
        public PageRequest PageRequest { get; set; }

        


        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
        {

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            

            public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
               IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                BrandListModel mappedbrandList =  _mapper.Map<BrandListModel>(brands);
                return mappedbrandList;

            }
        }


    }
}
