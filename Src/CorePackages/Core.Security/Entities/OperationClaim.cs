using Core.Persistence.Repositories;
using Domain.Entites.Common;

namespace Core.Security.Entities;



//Kullanıcının role bilgilerini ve ya daha fazla farklı bilgilerini de içerebilir.Temel olarak projelerde kullanıcı rollerini tutar.
public class OperationClaim : BaseEntity
{
    public string Name { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(int id, string name) : base(id)
    {
        Name = name;
    }
}