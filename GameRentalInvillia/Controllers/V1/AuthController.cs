using System.Threading.Tasks;
using GameRentalInvillia.Application.ViewModel.Account;
using GameRentalInvillia.Web.Services.JWT.Interfaces;
using GameRentalInvillia.Web.Services.JWT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/v1/[controller]"), ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly IRefreshTokenFactory _refreshTokenFactory;
        private readonly ILogger _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(IJwtFactory jwtFactory,
            IRefreshTokenFactory refreshTokenFactory,
            ILogger<AuthController> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _jwtFactory = jwtFactory;
            _refreshTokenFactory = refreshTokenFactory;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }


        [HttpPost, Produces("application/json", Type = typeof(AccessToken))]
        public async Task<IActionResult> Login(AuthModel authModel)
        {
            _logger.LogInformation("Started method Login");
            var user = await _userManager.FindByEmailAsync(authModel.Email);
            if (user == null)
                return BadRequest("Invalid user");
            var result = await _signInManager.PasswordSignInAsync(user, authModel.Password, false, false);
            if (!result.Succeeded)
                return BadRequest("Incorrect password");
            var temp = await _jwtFactory.GenerateEncodedToken(user.Id, authModel.Email);
            _logger.LogInformation("Successfully generated token");
            return Ok(temp);
        }

        [HttpGet, Route("validate"), Produces("application/json", Type = typeof(string))]
        public IActionResult AccessTokenValidate(string accessToken)
        {
            _logger.LogInformation("Started method AccessTokenValidate");
            return Ok(_jwtFactory.ValidateToken(accessToken));
        }

        [HttpGet, Route("refresh"), Produces("application/json", Type = typeof(string))]
        public IActionResult RefreshToken()
        {
            _logger.LogInformation("Started method RefreshToken");
            return Ok(_refreshTokenFactory.GenerateRefreshToken());
        }
    }
}
