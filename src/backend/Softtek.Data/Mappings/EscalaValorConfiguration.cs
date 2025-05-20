using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;

namespace Softtek.Data.Mappings;

public class EscalaValorConfiguration : IEntityTypeConfiguration<EscalaValor>
{
    public void Configure(EntityTypeBuilder<EscalaValor> builder)
    {
        builder.HasKey(ev => ev.Codigo);

        builder.Property(ev => ev.Codigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.Property(ev => ev.Descricao)
               .IsRequired()
               .HasMaxLength(100);
    }
}
