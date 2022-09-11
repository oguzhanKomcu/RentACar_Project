using Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Model : BaseEntity
    {

        public int BrandId { get; set; }
        public virtual Brand? Brand { get; set; } //brand null gelebilir diye "?" brande ekledik.
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string  ImageUrl { get; set; }



        public Model()
        {

        }

        public Model(int id,int brandId,string name, decimal dailyPrice, string ımageUrl) : this()//ctorumuzu hazır veri  girişi yaparken kullanıyoruz.
        {
            Id = id;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = ımageUrl;
            BrandId = brandId;
            
        }
    }
}
