using Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Brand : BaseEntity //ileriye dönük soyutlama problemi kalmaması için ve
                                    //bir veritabanı nesnesi olmasını belirtmek için BaseEntity ekledik.
    {
        public string Name { get; set; }

        public Brand()
        {

        }

        public Brand(int id, string name) : this()//this diyerek bu classın parametresiz constructorınıda böyle çalıştır dedik
        {
            Name = name;
            this.Id = id;
        }

    }
}
