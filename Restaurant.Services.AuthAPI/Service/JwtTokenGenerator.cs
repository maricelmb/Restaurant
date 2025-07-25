﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Services.AuthAPI.Models;
using Restaurant.Services.AuthAPI.Service.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant.Services.AuthAPI.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JWTOptions _jwtOptions;
        public JwtTokenGenerator(IOptions<JWTOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public string GenerateToken(ApplicationUser applicationUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
            
            var claimList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
               Audience = _jwtOptions.Audience,
               Issuer = _jwtOptions.Issuer,
               Subject = new ClaimsIdentity(claimList),
               Expires = DateTime.UtcNow.AddDays(7),
               SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
