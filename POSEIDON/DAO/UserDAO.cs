using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using POSEIDON.Core;
using POSEIDON.DTO;
using POSEIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace POSEIDON.DAO
{
  public class UserDAO
  {
    private readonly PoseidonContext _context;

    /// <summary>
    /// Mensaje de error
    /// </summary>
    public CustomError customError;
    
    public UserDAO(PoseidonContext context)
    {
      _context = context;
    }
    public async Task<bool> addAsync(User user)
    {
      _context.User.Add(user);
      Security security = new Security();
      user.Aditional = security.GetSalt();
      user.Password = security.GetHash(user.Aditional + user.Password);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<TokenDTO> LoginAsync(LoginDTO loginDTO, IConfiguration config)
    {
      TokenDTO tokenDTO = new TokenDTO();
      Security segurity = new Security();
      Token token = new Token(config);
      var user = await _context.User.FirstOrDefaultAsync(usu => usu.Account == loginDTO.User);
      if (user == null)
      {
        customError = new CustomError(400, String.Format("GeneralNoExiste","La clave del usuario"));
        return tokenDTO;
      }
      if (user.Password != segurity.GetHash(user.Aditional + loginDTO.Password))
      {
        customError = new CustomError(400, "PasswordIncorrecto");
        return tokenDTO;
      }
      if (!user.Active)
      {
        customError = new CustomError(403, "UsuarioInactivo");
        return tokenDTO;
      }
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Sid, user.Id.ToString()),
      };
      RolDAO rolDAO = new RolDAO(_context);
      var rols = rolDAO.GetRolsByUsers(user.Id);
      foreach (var rol in rols)
      {
        claims.Add(new Claim(ClaimTypes.Role, rol));
      }
      DateTime dateExpiration = DateTime.Now.AddDays(15).ToLocalTime();
      tokenDTO.Token = token.GenerateToken(claims.ToArray(), dateExpiration);
      tokenDTO.TokenExpiration = dateExpiration;
      tokenDTO.UserId = user.Id;
      tokenDTO.RefreshToken = token.RefreshToken();
      return tokenDTO;
    }
  }
}
