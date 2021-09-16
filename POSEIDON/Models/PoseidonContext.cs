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
          Password = "34-9f-f4-38-5b-c9-40-56-d0-50-80-75-bb-38-e1-8b-ed-27-6d-0b-8d-34-65-38-bf-63-c9-57-9d-de-16-87",
          Active = true,
          Aditional = "42-04-b1-c7-9a-3f-9c-48-9c-ef-75-04-5a-d0-55-10",
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
          Password = "5c-73-4d-21-f1-d2-c8-d1-50-50-0b-e3-3a-d8-38-e3-12-b0-1d-d4-3f-4a-45-27-e6-85-13-d8-68-d6-b7-24",
          Active = true,
          Aditional = "25-ff-57-7d-1d-c4-ba-ca-d2-ac-8d-d5-a5-a0-2a-d3",
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
          Password = "5c-73-4d-21-f1-d2-c8-d1-50-50-0b-e3-3a-d8-38-e3-12-b0-1d-d4-3f-4a-45-27-e6-85-13-d8-68-d6-b7-24",
          Active = true,
          Aditional = "65-d1-9a-4a-7a-0e-c7-aa-54-75-55-ec-cd-a0-dd-cf",
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
