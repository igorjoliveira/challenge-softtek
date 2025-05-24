using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;

public class QuestionarioMapping : IEntityTypeConfiguration<Questionario>
{
    public void Configure(EntityTypeBuilder<Questionario> builder)
    {
        builder.ToTable("Questionarios");

        builder.HasKey(q => q.Codigo);

        builder.Property(q => q.Codigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.Property(q => q.DataPreenchimento)
               .IsRequired();

        builder.Property(q => q.BlocoDePerguntaCodigo)
               .IsRequired();

        builder.HasOne(q => q.BlocoDePergunta)
               .WithMany()
               .HasForeignKey(q => q.BlocoDePerguntaCodigo)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(q => q.Respostas)
               .WithOne()
               .HasForeignKey(r => r.PerguntaCodigo)
               .OnDelete(DeleteBehavior.Restrict);
    }
}