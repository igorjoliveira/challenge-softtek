using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softtek.Domain.Aggregates.AssistenciaEmocional;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos;

public class RecursoDeApoioMapping : IEntityTypeConfiguration<RecursoDeApoio>
{
    public void Configure(EntityTypeBuilder<RecursoDeApoio> builder)
    {
        builder.ToTable("RecursosDeApoio");

        builder.Property(r => r.Link)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(r => r.Tipo)
            .IsRequired();

        builder.Property(r => r.Categoria)
            .HasMaxLength(100);

        builder.HasOne<ApoioBase>()
               .WithOne()
               .HasPrincipalKey<ApoioBase>(a => a.Codigo)
               .HasForeignKey<RecursoDeApoio>(a => a.Codigo)
               .OnDelete(DeleteBehavior.Cascade);
    }
}