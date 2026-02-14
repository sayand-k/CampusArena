using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CampusArena.Services;

namespace CampusArena.Controllers
{
    [Route("api/[controller]")] // This makes the URL: api/account
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;

        // We ask .NET to hand us the "User Manager" and our "Token Service"
        public AccountController(UserManager<IdentityUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")] // This makes the URL: api/account/login
        public async Task<IActionResult> Login(string email, string password)
        {
            // 1. Find the user by email
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return Unauthorized("Invalid Email");

            // 2. Check if the password is correct
            var result = await _userManager.CheckPasswordAsync(user, password);

            if (!result) return Unauthorized("Invalid Password");

            // 3. Get the user's roles (Admin, Scorer, etc.)
            var roles = await _userManager.GetRolesAsync(user);

            // 4. Generate the "Wristband" (JWT Token)
            var token = _tokenService.CreateToken(user, roles);

            // 5. Send the token back to the user
            return Ok(new
            {
                Email = user.Email,
                Token = token
            });
        }
    }
}