using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.Auths.Services
{
    public class AuthManager : IAuthService
    {

        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        //Token helper Core.Securityden gelmektedir.
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            var addrefreshtoken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addrefreshtoken;
        }
        public async Task<AccessToken> CreateAccessToken(User user)
        {

            //Userlar ve o userların claimlerinide/rollerini de çek
            IPaginate < UserOperationClaim > userOperationClaims =
                await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                           include: u =>
                             u.Include(u => u.OperationClaim)
                      );


            //claimlerden ıd ve ismini çek lisetele
            IList < OperationClaim > operationClaims =
            userOperationClaims.Items.Select(u => new OperationClaim
           {
                Id = u.OperationClaim.Id , Name = u.OperationClaim.Name 
            }) .ToList();

            //ve bir token oluştur
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }
        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return Task.FromResult(refreshToken);
        }
    }
}
