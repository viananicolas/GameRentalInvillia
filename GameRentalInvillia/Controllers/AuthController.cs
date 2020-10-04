using System;
using System.Threading.Tasks;
using GameRentalInvillia.Web.Models;
using GameRentalInvillia.Web.Services.JWT.Interfaces;
using GameRentalInvillia.Web.Services.JWT.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalInvillia.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly IRefreshTokenFactory _refreshTokenFactory;

        public AuthController(IJwtFactory jwtFactory, IRefreshTokenFactory refreshTokenFactory)
        {
            _jwtFactory = jwtFactory;
            _refreshTokenFactory = refreshTokenFactory;
        }

        [HttpPost]
        [Route("AccessTokenGenerate")]
        public async Task<AccessToken> AccessToken(AuthModel authModel)
        {
            var temp = await _jwtFactory.GenerateEncodedToken(authModel.Id, authModel.Email, authModel.Name, authModel.Roles);
            return temp;
        }

        [HttpGet]
        [Route("AccessTokenValidate")]
        public Guid? AccessTokenValidate(string accessToken)
        {
            return _jwtFactory.ValidateToken(accessToken);
        }

        [HttpGet]
        [Route("RefreshTokenGenerate")]
        public string RefreshToken()
        {
            return _refreshTokenFactory.GenerateRefreshToken();
        }
    }
}
