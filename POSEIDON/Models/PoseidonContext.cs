using Microsoft.EntityFrameworkCore;
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
