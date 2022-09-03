using Application.Features.BrandFeature.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BrandFeature.Models
{
    public class BrandListModel  : BasePageableModel
    {
        //Bu model içinde heme sayfalama bilgisini hemde catoryleri dönmek için

        public IList<BrandListDto> Items { get; set; }



    }
}
