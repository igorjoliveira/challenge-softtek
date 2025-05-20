using Microsoft.EntityFrameworkCore;
using Softtek.Data.Mappings;
using Softtek.Data.Seed;
using Softtek.Domain.Aggregates.AssistenciaEmocional;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;

namespace Softtek.Data.Context;

public class SofttekDbContext : DbContext
{
    public DbSet<AvaliacaoAggregate> Avaliacoes { get; set; } = null!;
    public DbSet<BlocoDePergunta> BlocosDePergunta { get; set; } = null!;
    public DbSet<Pergunta> Perguntas { get; set; } = null!;
    public DbSet<EscalaBase> Escalas { get; set; } = null!;
    public DbSet<EscalaValor> EscalaValores { get; set; } = null!;
    public DbSet<EscalaBaseValor> EscalaBaseValores { get; set; } = null!;
    public DbSet<ApoioBase> Apoios { get; set; } = null!;
    public DbSet<Lembrete> Lembretes { get; set; } = null!;
    public DbSet<Notificacao> Notificacoes { get; set; } = null!;
    public DbSet<RecursoDeApoio> RecursosDeApoio { get; set; } = null!;

    public SofttekDbContext(DbContextOptions<SofttekDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //CriarContextoAvaliacaoPsicossocial
        modelBuilder.ApplyConfiguration(new AvaliacaoConfiguration());
        modelBuilder.ApplyConfiguration(new BlocoDePerguntaConfiguration());
        modelBuilder.ApplyConfiguration(new PerguntaConfiguration());
        modelBuilder.ApplyConfiguration(new EscalaBaseConfiguration());
        modelBuilder.ApplyConfiguration(new EscalaValorConfiguration());
        modelBuilder.ApplyConfiguration(new EscalaBaseValorConfiguration());

        //CriarContextoAssistenciaEmocional
        modelBuilder.ApplyConfiguration(new AssistenciaMapping());
        modelBuilder.ApplyConfiguration(new ApoioBaseMapping());
        modelBuilder.ApplyConfiguration(new LembreteMapping());
        modelBuilder.ApplyConfiguration(new NotificacaoMapping());
        modelBuilder.ApplyConfiguration(new RecursoDeApoioMapping());

        //MonitoramentoEmocional
        modelBuilder.ApplyConfiguration(new QuestionarioMapping());
        modelBuilder.ApplyConfiguration(new RespostaMapping());

        // Seed Data
        AvaliacaoSeed.Seed(modelBuilder);
    }
}
