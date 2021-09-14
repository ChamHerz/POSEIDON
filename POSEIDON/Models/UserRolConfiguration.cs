using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.Models
{
  public class UserRolConfiguration : IEntityTypeConfiguration<UserRol>
  {
    public void Configure(EntityTypeBuilder<UserRol> builder)
    {
      builder.HasIndex(u => new { u.UserId, u.RolId })
         .HasName("UI_UsuarioRol")
         .IsUnique();

      builder.HasOne(typeof(User))
             .WithMany()
             .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(typeof(Rol))
             .WithMany()
             .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
