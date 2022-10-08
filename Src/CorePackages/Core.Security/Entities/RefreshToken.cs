﻿using Core.Persistence.Repositories;
using Domain.Entites.Common;

namespace Core.Security.Entities;


//Refresh token , kullanıcının token süresi bittiğinde tekar tekrar girmesini engellemek için talep ettiğimiz token için kurduğumuz bir yapı
public class RefreshToken : BaseEntity
{
    public int UserId { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? Revoked { get; set; }
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; }

    public string? ReasonRevoked { get; set; }
    //public bool IsExpired => DateTime.UtcNow >= Expires;
    //public bool IsRevoked => Revoked != null;
    //public bool IsActive => !IsRevoked && !IsExpired;

    public virtual User User { get; set; }

    public RefreshToken()
    {
    }

    public RefreshToken(int id, string token, DateTime expires, DateTime created, string createdByIp, DateTime? revoked,
                        string revokedByIp, string replacedByToken, string reasonRevoked)
    {
        Id = id;
        Token = token;
        Expires = expires;
        Created = created;
        CreatedByIp = createdByIp;
        Revoked = revoked;
        RevokedByIp = revokedByIp;
        ReplacedByToken = replacedByToken;
        ReasonRevoked = reasonRevoked;
    }
}