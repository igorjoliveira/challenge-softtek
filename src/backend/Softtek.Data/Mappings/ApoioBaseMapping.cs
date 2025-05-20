using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.AssistenciaEmocional;

public class ApoioBaseMapping : IEntityTypeConfiguration<ApoioBase>
{
    public void Configure(EntityTypeBuilder<ApoioBase> builder)
    {
        builder.ToTable("Apoios");
        builder.HasKey(a => a.Codigo);

        builder.Property(e => e.Codigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.Property(a => a.Titulo)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.Descricao)
            .HasMaxLength(500);

        builder.Property(a => a.DataCriacao)
            .IsRequired();

        builder.HasOne(a => a.ApoioAggregate)
            .WithMany(ag => ag.Apoios)
            .HasForeignKey(a => a.ApoioAggregateId);
    }
}