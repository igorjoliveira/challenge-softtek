using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

namespace Softtek.Data.Mappings;

public class PerguntaConfiguration : IEntityTypeConfiguration<Pergunta>
{
    public void Configure(EntityTypeBuilder<Pergunta> builder)
    {
        builder.HasKey(p => p.Codigo);

        builder.Property(p => p.Codigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.Property(p => p.Descricao)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(p => p.Desativado)
               .IsRequired(false);

        builder.HasOne(p => p.Escala)
               .WithMany()
               .HasForeignKey(p => p.EscalaCodigo)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
