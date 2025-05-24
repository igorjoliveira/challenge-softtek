namespace Softtek.Domain.Aggregates.AssistenciaEmocional.Commands
{
    public readonly record struct NovoRecursoDeApoio(string Titulo, string Link, TipoRecurso Tipo, string? Categoria = null);
}
