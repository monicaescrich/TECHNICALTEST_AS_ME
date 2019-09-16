using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHNICALTEST_AS_ME.Domains.Services.Responses;

namespace TECHNICALTEST_AS_ME.Domains.Services
{
    public interface IAuthenticationService
    {
        Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
        Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
        void RevokeRefreshToken(string refreshToken);
    }
}
