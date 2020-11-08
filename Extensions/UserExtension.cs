using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Twitter.Domain.Models;

namespace Twitter.Extensions
{
    public static class UserExtension
    {
        public static void GenerateTokenString(this User user, string secret, int expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();//our token
            var key = Encoding.ASCII.GetBytes(secret);//key from our secret
            var claims = new List<Claim>{
                                    new Claim(ClaimTypes.Name, user.User_login) };//list of claims
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),//token theme
                Expires = DateTime.UtcNow.AddMinutes(expires),//token lifetime
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                                                            SecurityAlgorithms.HmacSha256Signature)
            };
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(createdToken);
        }
    }
}