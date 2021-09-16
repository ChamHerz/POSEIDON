using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POSEIDON.Core
{
  public class Token
  {
    protected readonly IConfiguration Config;

    public Token(IConfiguration config)
    {
      Config = config;
    }

    public string GenerateToken(Claim[] claims, DateTime dateExpiration)
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Tokens:Key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      JwtSecurityToken jwtToken = new JwtSecurityToken
                 (Config["Tokens:Issuer"],
                  Config["Tokens:Issuer"],
                  claims,
                  expires: dateExpiration,
                  signingCredentials: creds);
      string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
      return token;
    }

    public string RefreshToken()
    {
      var randomNumber = new byte[32];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber)
            .Replace("$", "1").Replace("/", "2")
            .Replace("&", "3").Replace("+", "4")
            .Replace("-", "5").Replace("?", "6");
      }
    }
  }
}
