using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test.api.models.DTOs;

namespace test.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var IdentityUser = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Username
            };
            var identityResult = await userManager.CreateAsync(IdentityUser,registerDto.Password);
            if(identityResult.Succeeded)
            {
                if(registerDto.roles != null && registerDto.roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(IdentityUser, registerDto.roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("register succesfull");
                    }
                }
            }
            return BadRequest("something went wrong");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Username);
            if(user != null)
            {
                var checkPassResult = await userManager.CheckPasswordAsync(user, loginDto.Password);
                if (checkPassResult)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
