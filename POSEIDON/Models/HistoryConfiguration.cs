using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSEIDON.Models
{
  public class HistoryConfiguration : IEntityTypeConfiguration<History>
  {
    public void Configure(EntityTypeBuilder<History> builder)
    {
      builder.HasIndex(h => h.TableId)
              .HasName("IX_HistoryTable");

      builder.HasIndex(e => e.UserId)
          .HasName("IX_ctrUser");

      builder.HasIndex(e => new { e.Activity, e.TableId, e.Timestamp })
          .HasName("IX_Activity");

      builder.HasIndex(e => new { e.TableId, e.OriginId, e.Activity })
          .HasName("IX_History");

      builder.HasOne(typeof(Table))
          .WithMany()
          .OnDelete(DeleteBehavior.Restrict);

      builder.HasOne(typeof(User))
          .WithMany()
          .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
