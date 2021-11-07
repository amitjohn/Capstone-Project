using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GymUserApi.Service
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string GenerateToken(Claim[] authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_my_signing_key"));

            var token = new JwtSecurityToken(
                issuer: "GymUserApi",
                audience: "GymApi",
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                //expiration = token.ValidTo
            };
            return JsonConvert.SerializeObject(response);
        }
    }
}
