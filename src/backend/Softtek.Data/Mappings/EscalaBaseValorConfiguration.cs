using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;

namespace Softtek.Data.Mappings;

public class EscalaBaseValorConfiguration : IEntityTypeConfiguration<EscalaBaseValor>
{
    public void Configure(EntityTypeBuilder<EscalaBaseValor> builder)
    {
        builder.HasKey(e => new { e.EscalaBaseCodigo, e.EscalaValorCodigo });

        builder.Property(e => e.EscalaBaseCodigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.Property(e => e.EscalaValorCodigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.HasOne(e => e.EscalaBase)
               .WithMany(e => e.ValoresAceitos)  
               .HasForeignKey(e => e.EscalaBaseCodigo)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.EscalaValor)
               .WithMany() 
               .HasForeignKey(e => e.EscalaValorCodigo)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
