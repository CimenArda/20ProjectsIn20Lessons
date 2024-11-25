using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTProject.JWT
{
    public class TokenGenerator
    {

        public string GenerateJwtToken(string UserName,string Email,string name,string surname)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ardacimentoken+-*JwtToken!ardacimentoken+-*JwtToken!"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimExample = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,UserName),
                new Claim(JwtRegisteredClaimNames.Email,Email),
                new Claim(JwtRegisteredClaimNames.GivenName,name),
                new Claim(JwtRegisteredClaimNames.FamilyName,surname),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(

                    issuer: "localhost",
                    audience: "localhost",
                    claims: claimExample,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: credentials

                );

            return new JwtSecurityTokenHandler().WriteToken(token);







        }
        public string GenerateJwtToken2(string UserName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ardacimentoken+-*JwtToken!ardacimentoken+-*JwtToken!"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimExample = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(

                    issuer: "localhost",
                    audience: "localhost",
                    claims: claimExample,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: credentials

                );

            return new JwtSecurityTokenHandler().WriteToken(token);







        }

    }
}
