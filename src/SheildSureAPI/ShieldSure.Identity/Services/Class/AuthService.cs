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
using Microsoft.Identity.Client;
using Microsoft.Extensions.Configuration;

namespace ShieldSure.Identity.Services.Class
{
    public class AuthService  : IAuthService
    {
        public readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwtToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
