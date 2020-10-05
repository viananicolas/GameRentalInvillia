using System.Linq;
using System.Threading.Tasks;
using GameRentalInvillia.Application.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/[controller]"), ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;
        public AccountController(UserManager<IdentityUser> userManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            _logger.LogInformation("Started method Register");
            var identityUser = new IdentityUser { Email = registerViewModel.Email, UserName = registerViewModel.Email };
            var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
            _logger.LogInformation("Registration result: {result}", result);
            if (result.Succeeded)
                return Ok("Created successfully");
            var errors = result.Errors.Select(e => e.Description);
            _logger.LogError("Error registering user: {errors}", errors);
            return BadRequest(errors);
        }
    }
}
