using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.AssistenciaEmocional;

namespace Softtek.Data.Mappings;

public class AssistenciaMapping : IEntityTypeConfiguration<AssistenciaAggregate>
{
    public void Configure(EntityTypeBuilder<AssistenciaAggregate> builder)
    {
        builder.ToTable("Assistencia");
        builder.HasKey(a => a.Codigo);

        builder.Property(a => a.Codigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.HasMany(a => a.Apoios)
               .WithOne(a => a.ApoioAggregate)
               .HasForeignKey(a => a.ApoioAggregateId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}