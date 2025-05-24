using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softtek.Domain.Aggregates.AssistenciaEmocional;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos;

public class NotificacaoMapping : IEntityTypeConfiguration<Notificacao>
{
    public void Configure(EntityTypeBuilder<Notificacao> builder)
    {
        builder.ToTable("Notificacoes");

        builder.Property(n => n.NivelGravidade)
            .HasMaxLength(50);

        builder.Property(n => n.Urgente)
            .IsRequired();

        builder.HasOne<ApoioBase>()
               .WithOne()
               .HasPrincipalKey<ApoioBase>(a => a.Codigo)
               .HasForeignKey<Notificacao>(a => a.Codigo)
               .OnDelete(DeleteBehavior.Cascade);
    }
}