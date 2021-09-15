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
      string salt1 = "74-52-ce-27-66-ca-0a-7c-51-00-8d-7b-e1-78-d0-ae";
      string salt2 = "cf-17-d4-ee-b2-23-b3-d6-43-aa-4e-d2-e8-53-f4-cf";
      string salt3 = "d3-7a-d4-f5-f3-a4-f5-a0-8f-43-54-41-83-9b-b3-a2";
      modelBuilder.Entity<User>().HasData(
        new User
        {
          Id = 1,
          Account = "ARMADA\\DIAP197",
          Key = "CHAMBI",
          Password = "f7-aa-92-99-41-1e-42-6b-06-6b-60-00-17-bb-b3-7d-60-2b-37-d0-91-4d-db-0c-11-70-13-12-59-64-96-88",
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
          Password = "9a-ff-21-83-28-cd-22-6c-27-4b-2d-dd-6c-c9-85-29-9a-e0-64-08-e3-7e-af-a2-91-bf-fb-89-72-b4-7c-ac",
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
          Password = "20-2d-f1-5b-03-76-7d-41-93-86-be-89-63-22-49-ae-9a-49-19-3c-4e-e0-7a-71-9a-3a-a1-15-a3-e7-2c-49",
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
