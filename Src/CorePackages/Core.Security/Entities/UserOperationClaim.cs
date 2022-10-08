using Core.Persistence.Repositories;
using Domain.Entites.Common;

namespace Core.Security.Entities;


//User ile rolleri ilişkilendirdiğimiz modelimiz
public class UserOperationClaim : BaseEntity
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; } //admin , user, vss

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
    }

    public UserOperationClaim(int id, int userId, int operationClaimId) : base(id)
    {
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}