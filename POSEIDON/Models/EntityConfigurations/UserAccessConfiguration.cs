using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.Models
{
  public class UserAccessConfiguration : IEntityTypeConfiguration<UserAccess>
  {
    public void Configure(EntityTypeBuilder<UserAccess> builder)
    {
      builder.HasOne(typeof(User))
          .WithMany()
          .OnDelete(DeleteBehavior.Restrict);

      builder.HasIndex(u => u.RefreshToken)
          .HasName("UI_RefreshToken")
          .IsUnique();

      builder.HasIndex(u => new { u.UserId, u.Token })
          .HasName("UI_Token")
          .IsUnique();
    }
  }
}
