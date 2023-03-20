using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportStore.IdentityServer.Dtos;
using SportStore.IdentityServer.Models;
using SportStore.Shared.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser { UserName = signUpDto.UserName, Email = signUpDto.Email, City = signUpDto.City };
            var result = await _userManager.CreateAsync(user, signUpDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 404));
            }

            return NoContent();
        }

    }
}
