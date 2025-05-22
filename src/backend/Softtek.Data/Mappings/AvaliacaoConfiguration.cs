using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

namespace Softtek.Data.Mappings;

public class AvaliacaoConfiguration : IEntityTypeConfiguration<AvaliacaoAggregate>
{
    public void Configure(EntityTypeBuilder<AvaliacaoAggregate> builder)
    {
        builder.HasKey(a => a.Codigo);

        builder.Property(a => a.Codigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.Property(a => a.DataCriacao)
               .IsRequired();

        builder.HasMany(a => a.BlocosDePergunta)
               .WithOne(b => b.Avaliacao)
               .HasForeignKey(b => b.AvaliacaoCodigo)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
