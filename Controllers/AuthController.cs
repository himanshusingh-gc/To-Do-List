using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using JWTAuthentication_TokenBarer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using To_Do_List.Models;

namespace To_Do_List.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppSettings _appSettings;
        
        // constructor to inject app settings
        public AuthController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        
        // Authenticate the user
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)
        {
            
            // create token here if user found
            var authUser = UserManager.users.SingleOrDefault(
                u => u.UserName == user.UserName && u.Password == user.Password);

            if (authUser == null)
            {
                return BadRequest("Invalid username or password");
            }
            else
            {
                // generate and return token
                var token = GenerateJwtToken(authUser);
                return Ok(token);
            }
        }
        
        // generates jwt token which is valid for 30 mins
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);        
        }
    }
}