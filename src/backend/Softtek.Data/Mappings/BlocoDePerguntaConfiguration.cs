using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

namespace Softtek.Data.Mappings;

public class BlocoDePerguntaConfiguration : IEntityTypeConfiguration<BlocoDePergunta>
{
    public void Configure(EntityTypeBuilder<BlocoDePergunta> builder)
    {
        builder.HasKey(b => b.Codigo);

        builder.Property(b => b.Codigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.Property(b => b.Titulo)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(b => b.Frequencia)
               .IsRequired();

        builder.HasMany(b => b.Perguntas)
               .WithOne(p => p.Bloco)
               .HasForeignKey(p => p.BlocoDePerguntaCodigo)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
