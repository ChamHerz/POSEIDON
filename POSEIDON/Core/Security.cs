using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POSEIDON.Core
{
  public class Security
  {
    public Security()
    {

    }
    public string GetSalt()
    {
      byte[] bytes = new byte[128 / 8];
      using (var keyGenerator = RandomNumberGenerator.Create())
      {
        keyGenerator.GetBytes(bytes);
        return BitConverter.ToString(bytes).ToLower();
      }
    }

    public string GetHash(string text)
    {
      using (var sha256 = SHA256.Create())
      {
        var hashedBytes = sha256
                .ComputeHash(Encoding.UTF8.GetBytes(text));
        return BitConverter
             .ToString(hashedBytes).ToLower();
      }
    }
  }
}
