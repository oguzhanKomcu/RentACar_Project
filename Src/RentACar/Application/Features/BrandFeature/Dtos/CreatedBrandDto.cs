using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BrandFeature.Dtos
{

     //İşlem sonrası döndürülecek sınıf.Yani eklenilen varlığı
     //görmek isteyen kullanıcı için Id ve Name alanlarını göstericek
    public class CreatedBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
