using NUlid;

namespace Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos
{
    public class RecursoDeApoio : ApoioBase
    {
        public required string Link { get; set; }
        public TipoRecurso Tipo { get; set; }
        public string? Categoria { get; set; }

        public RecursoDeApoio(string titulo, string link, TipoRecurso tipo, string? categoria = null)
        {
            Codigo = Ulid.NewUlid();
            Titulo = titulo;
            Link = link;
            Tipo = tipo;
            Categoria = categoria;
        }
    }
}
