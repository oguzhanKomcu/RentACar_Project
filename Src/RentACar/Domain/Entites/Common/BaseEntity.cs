using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.Common
{
    public class BaseEntity
    {
        public int  Id { get; set; }
        public DateTime CreateDate { get; set; }
        public  DateTime? UpdateDate { get; set; }
         public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
        public BaseEntity()
        {
        }

        public BaseEntity(int id) : this()
        {
            Id = id;
        }
    }
}
