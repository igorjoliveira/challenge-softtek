namespace Softtek.Domain.Aggregates.AssistenciaEmocional.Commands
{
    public readonly record struct NovoLembrete(string Titulo, string Descricao, DateTime DataAgendada);
}
