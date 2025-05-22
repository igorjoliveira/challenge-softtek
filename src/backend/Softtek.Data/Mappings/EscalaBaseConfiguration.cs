using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala.Tipos;

namespace Softtek.Data.Mappings;

public class EscalaBaseConfiguration : IEntityTypeConfiguration<EscalaBase>
{
    public void Configure(EntityTypeBuilder<EscalaBase> builder)
    {
        builder.HasKey(e => e.Codigo);

        builder.Property(e => e.Codigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.Property(e => e.Descricao)
               .IsRequired()
               .HasMaxLength(150);

        builder.HasDiscriminator<string>("Discriminator")
               .HasValue<EmocaoEscala>("Emocao")
               .HasValue<HumorEscala>("Humor")
               .HasValue<IntensidadeEscala>("Intensidade")
               .HasValue<FrequenciaEscala>("Frequencia")
               .HasValue<PontuacaoEscala>("Pontuacao");
    }
}
