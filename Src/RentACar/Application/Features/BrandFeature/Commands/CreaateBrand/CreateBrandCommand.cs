using Application.Features.BrandFeature.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BrandFeature.Commands.CreaateBrand
{
    //Kullanıcın verileri veritabanına eklemek için dolduracağı alanları
    //tanımlıyoruz ve geri dönüş olarak gösterilemsi gereken alanları tutan
    //Dto sınıfımızı Irequest tarafına tanımlıyourz ve aslında IRequest interfaceini kullanrak imzalıyourz. 
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        public string Name { get; set; }



        //Tüm handlerlarımızı IRequestHandler ile bir listeye ekliyoruz. İtsediği request ve response sınıflarını sırasıyla veriyoruz.
        //Böyle bir command sıraya koyulursa bu handlerve içindeki gerekli kodlar çalışacak diye belirtiyoruz.
        //Handler sınıfı istenilirse ayrı bir sınıfta da oluşturulabilinir.
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                var mappedBrand = _mapper.Map<Brand>(request); // Gelen requestteki verileri brand modelindeki alanlara atamayı mapper ile yapıyoruz.
                var createdBrand = await _brandRepository.AddAsync(mappedBrand); //Veritabanına eklenilen varlık sonucu geri dönen alanlarını Brand modeline atıyoruz
                var createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand);//Geri dönüşümüz  CreatedBrandDto oldugu için Brand modeliyle gelen verileri mapledik

                return createdBrandDto;
            }
        }

    }
}
