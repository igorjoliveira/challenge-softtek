namespace Softtek.Domain.Aggregates.AssistenciaEmocional.Commands
{
    public readonly record struct NovaNotificacao(string Titulo, string Descricao, bool Urgente = false, string? NivelGravidade = null);
}
