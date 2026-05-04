using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShieldSure.Identity.DTOs;
using ShieldSure.Identity.Models;
using System.ClientModel.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ShieldSure.Identity.Services.Interfaces;


namespace ShieldSure.Identity.Controllers                      
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "User created successfully!" });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {           
            var User = await _userManager.FindByEmailAsync(loginDto.Email);

            if (User != null && await _userManager.CheckPasswordAsync(User, loginDto.Password))
            {
                var token = _authService.GenerateJwtToken(User);
                return Ok(new { token = token });
            }

            return Unauthorized();
        }



        [Authorize]
        [HttpGet("test-auth")]
        public IActionResult TestAuth()
        {
            return Ok(new { message = "Great you have been authenticated with the JWT" });
        }

        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            // These are pulled directly from the decrypted JWT
            var firstName = User.FindFirst("firstName")?.Value;
            var department = User.FindFirst("dept")?.Value;

            return Ok($"Hello {firstName} from the {department} department!");
        }

    }
}