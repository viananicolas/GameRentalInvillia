using System;
using System.Security.Cryptography;
using GameRentalInvillia.Web.Services.JWT.Interfaces;
using GameRentalInvillia.Web.Services.JWT.Options;
using Microsoft.Extensions.Options;

namespace GameRentalInvillia.Web.Services.JWT.Services
{
    public class RefreshTokenFactory : IRefreshTokenFactory
    {
        private readonly JwtOption _jwtOption;

        public RefreshTokenFactory(IOptions<JwtOption> jwtOption)
        {
            _jwtOption = jwtOption.Value;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[_jwtOption.SizeRefreshToken];
            using var rng = RandomNumberGenerator.Create();

            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
