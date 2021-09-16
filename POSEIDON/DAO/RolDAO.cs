using POSEIDON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.DAO
{
  public class RolDAO
  {
    private readonly PoseidonContext context;

    public RolDAO(PoseidonContext context)
    {
      this.context = context;
    }

    public List<string> GetRolsByUsers(int userId)
    {
      return (from userRol in context.UserRol
              join rol in context.Rol
                  on userRol.RolId equals rol.Id
              where userRol.UserId == userId
              select rol.Name).ToList();
    }
  }
}
