using Microsoft.EntityFrameworkCore;
using POSEIDON.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.Models
{
  public class PoseidonContext : DbContext
  {
    public PoseidonContext(DbContextOptions<PoseidonContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Rol>().HasData(
             new Rol { Id = 1, Name = "ROOT" },
             new Rol { Id = 2, Name = "ADMIN" },
             new Rol { Id = 3, Name = "USER" }
      );

      modelBuilder.ApplyConfiguration(new HistoryConfiguration());
      modelBuilder.ApplyConfiguration(new UserAccessConfiguration());
      modelBuilder.ApplyConfiguration(new UserConfiguration());
      modelBuilder.ApplyConfiguration(new UserRolConfiguration());

      //#region Inserts User
      Security security = new Security();
      string salt1 = security.GetSalt();
      string salt2 = security.GetSalt();
      string salt3 = security.GetSalt();
      modelBuilder.Entity<User>().HasData(
        new User
        {
          Id = 1,
          Account = "ARMADA\\DIAP197",
          Key = "CHAMBI",
          Password = security.GetHash(salt1 + "n2r5u8x/A?D(G+KbPeSgVkYp3s6v9y$B"),
          Active = true,
          Aditional = salt1,
          Destine = "DIAP",
          Degree = "CP",
          LastName = "CHAMBI",
          FirstName = "DENIS ADRIEL",
          Authorized = true,
          Charge = "PROGRAMADOR",
          InternalPhone = "122462"
        },
        new User
        {
          Id = 2,
          Account = "ARMADA\\DIAP204",
          Key = "SALINAS",
          Password = security.GetHash(salt2 + "8y/B?D(G+KbPeShVmYq3t6w9z$C&F)H@"),
          Active = true,
          Aditional = salt2,
          Destine = "DIAP",
          Degree = "SM",
          LastName = "SALINAS",
          FirstName = "JOSE",
          Authorized = true,
          Charge = "ENCARGADO SEGUIMIENTO PROFESIONAL",
          InternalPhone = "122462"
        },
        new User
        {
          Id = 3,
          Account = "ARMADA\\DIAP233",
          Key = "TOLABA",
          Password = security.GetHash(salt3 + "(H+MbQeShVmYq3t6w9z$C&F)J@NcRfUj"),
          Active = true,
          Aditional = salt3,
          Destine = "DIAP",
          Degree = "CP",
          LastName = "TOLABA",
          FirstName = "MARIO",
          Authorized = true,
          Charge = "AUXILIAR SEGUIMIENTO PROFESIONAL",
          InternalPhone = "122462"
        }
        );

      modelBuilder.Entity<UserRol>().HasData(
        new UserRol
        {
          Id = 1,
          RolId = 3,
          UserId = 3
        },
        new UserRol
        {
          Id = 2,
          RolId = 2,
          UserId = 2
        },
        new UserRol
        {
          Id = 3,
          RolId = 1,
          UserId = 1
        }
        );
    }

    public virtual DbSet<History> History { get; set; }
    public virtual DbSet<Table> Table { get; set; }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<UserAccess> UserAccess { get; set; }
    public virtual DbSet<UserRol> UserRol { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    //ESTO PARA pasar los enum
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().ToTable("USER");

      modelBuilder.Entity<User>()
                .Property(c => c.role)
                .HasConversion<int>();

      base.OnModelCreating(modelBuilder);
    }*/
  }
}
