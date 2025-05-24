using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;

public class RespostaMapping : IEntityTypeConfiguration<Resposta>
{
    public void Configure(EntityTypeBuilder<Resposta> builder)
    {
        builder.ToTable("Respostas");

        builder.HasKey(r => r.Codigo);

        builder.HasIndex(r => new { r.QuestionarioCodigo, r.PerguntaCodigo, r.EscalaValorCodigo})
               .IsUnique()
               .HasDatabaseName("IX_Respostas_Questionario_Pergunta_EscalaValor")
               .HasFilter(null);

        builder.Property(r => r.Codigo)
               .HasConversion(
                   ulid => ulid.ToString(),
                   ulidString => Ulid.Parse(ulidString))
               .HasMaxLength(26);

        builder.Property(r => r.QuestionarioCodigo)
               .IsRequired();

        builder.Property(r => r.EscalaValorCodigo)
               .IsRequired();

        builder.Property(r => r.PerguntaCodigo)
               .IsRequired();

        builder.HasOne(r => r.EscalaValor)
               .WithMany()
               .HasForeignKey(r => r.EscalaValorCodigo)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Pergunta)
               .WithMany()
               .HasForeignKey(r => r.PerguntaCodigo)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Questionario)
               .WithMany()
               .HasForeignKey(r => r.QuestionarioCodigo)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
