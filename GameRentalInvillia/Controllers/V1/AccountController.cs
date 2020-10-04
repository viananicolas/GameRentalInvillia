using System.Linq;
using System.Threading.Tasks;
using GameRentalInvillia.Application.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/[controller]"), ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var identityUser = new IdentityUser { Email = registerViewModel.Email, UserName = registerViewModel.Email };
            var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
            if (result.Succeeded)
                return Ok("Created successfully");
            return BadRequest(result.Errors.Select(e => e.Description));
        }
    }
}
