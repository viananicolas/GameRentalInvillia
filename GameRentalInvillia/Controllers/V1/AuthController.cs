using System.Threading.Tasks;
using GameRentalInvillia.Application.ViewModel.Account;
using GameRentalInvillia.Web.Services.JWT.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/v1/[controller]"), ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly IRefreshTokenFactory _refreshTokenFactory;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(IJwtFactory jwtFactory,
            IRefreshTokenFactory refreshTokenFactory,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _jwtFactory = jwtFactory;
            _refreshTokenFactory = refreshTokenFactory;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> Login(AuthModel authModel)
        {
            var user = await _userManager.FindByEmailAsync(authModel.Email);
            if (user == null)
                return BadRequest("Invalid user");
            var result = await _signInManager.PasswordSignInAsync(user, authModel.Password, false, false);
            if (!result.Succeeded)
                return BadRequest("Incorrect password");
            var temp = await _jwtFactory.GenerateEncodedToken(user.Id, authModel.Email);
            return Ok(temp);
        }

        [HttpGet, Route("validate")]
        public IActionResult AccessTokenValidate(string accessToken)
        {
            return Ok(_jwtFactory.ValidateToken(accessToken));
        }

        [HttpGet, Route("refresh")]
        public IActionResult RefreshToken()
        {
            return Ok(_refreshTokenFactory.GenerateRefreshToken());
        }
    }
}
