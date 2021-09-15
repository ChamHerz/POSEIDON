using POSEIDON.Core;
using POSEIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.DAO
{
  public class UserDAO
  {
    private readonly PoseidonContext context;
    public async Task<bool> addAsync(User user)
    {
      context.User.Add(user);
      Security security = new Security();
      user.Aditional = security.GetSalt();
      user.Password = security.GetHash(user.Aditional + user.Password);
      await context.SaveChangesAsync();
      return true;
    }

  }
}
