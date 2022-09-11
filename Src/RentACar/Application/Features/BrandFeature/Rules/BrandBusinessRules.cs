using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BrandFeature.Rules
{

    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            //IPaginate sayfalama konusunda bize yardımcı olacak alanalrımızı bulunduruyor. 
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name == name);

            //eğer böyle bir marka varsa ife giricek ve exception fırlatıcak.KURALDAN GEÇMEDİĞİ HER DURUMDA HATA FIRLATIYOR.
            if (result.Items.Any()) throw new BusinessException("Some Featre Entty name exists.");
        }


        public async Task BrandShouldExistWhenRequested(int id)
        {
            var brand = await _brandRepository.GetListAsync(b => b.Id == id);

            if (brand == null) throw new BusinessException("Requested brand does not exist");
        }

        internal void BrandShouldExistWhenRequested(Brand? brand)
        {
            if (brand == null) throw new BusinessException("Requested brand does not exist");
        }
    }
}
