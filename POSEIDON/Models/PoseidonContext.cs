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
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().ToTable("USER");

      modelBuilder.Entity<User>()
                .Property(c => c.role)
                .HasConversion<int>();

      base.OnModelCreating(modelBuilder);
    }
  }
}
