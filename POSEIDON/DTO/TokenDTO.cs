using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.DTO
{
  /// <summary>
  /// Clase para el manejo de los tokens
  /// </summary>
  public class TokenDTO
  {
    /// <summary>
    /// Token generado.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Fecha de expiración del token.
    /// </summary>
    public DateTime TokenExpiration { get; set; }

    /// <summary>
    /// Número de control del usuario en sesión.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Nombre Usuario
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Codigo para refrescar el token
    /// </summary>
    public string RefreshToken { get; set; }
  }
}
