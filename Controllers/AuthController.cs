using blogfolio.Data;
using blogfolio.Dto;
using blogfolio.Dto.User;
using blogfolio.Entities;
using blogfolio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace blogfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //IConfiguration is an interface in ASP.NET Core that provides access to configuration settings.
        private readonly IConfiguration _config;
        private readonly BlogfolioContext _blogfolioContext;
        private readonly IUserService _userService;

        public AuthController(IConfiguration config, BlogfolioContext blogfolioContext, IUserService userService)
        {
            _config = config;
            _blogfolioContext = blogfolioContext;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            Console.WriteLine("work");
            // Find user by email (assuming email is the key; otherwise, use a query)
            var user = await _blogfolioContext.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            // TODO: Verify the user's password (e.g., using a password hasher)
            // if (!VerifyPassword(user, loginDto.Password))
            // {
            //     return Unauthorized("Invalid credentials");
            // }

            // Create claims for the token
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, loginDto.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            // Retrieve JWT settings from configuration
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");
            var issuer = jwtSettings.GetValue<string>("Issuer");
            var audience = jwtSettings.GetValue<string>("Audience");
            var expiryInHours = jwtSettings.GetValue<double>("ExpiryInHours");

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expiryInHours),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        public async Task<ActionResult<User>> RegisterUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException();
            }
            try
            {
                var res = await _userService.CreateUserAsync(createUserDto);
                return Ok(res);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex);
            }


        }

    }
}
