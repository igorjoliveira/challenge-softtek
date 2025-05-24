using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softtek.Domain.Aggregates.AssistenciaEmocional;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos;

public class LembreteMapping : IEntityTypeConfiguration<Lembrete>
{
    public void Configure(EntityTypeBuilder<Lembrete> builder)
    {
        builder.ToTable("Lembretes");

        builder.Property(l => l.DataAgendada)
            .IsRequired();

        builder.HasOne<ApoioBase>()
               .WithOne()
               .HasPrincipalKey<ApoioBase>(a => a.Codigo)
               .HasForeignKey<Lembrete>(a => a.Codigo)
               .OnDelete(DeleteBehavior.Cascade);
    }
}