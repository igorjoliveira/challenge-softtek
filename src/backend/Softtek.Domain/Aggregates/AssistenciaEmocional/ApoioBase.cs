using NUlid;

namespace Softtek.Domain.Aggregates.AssistenciaEmocional
{
    public abstract class ApoioBase
    {
        public Ulid Codigo { get; protected set; }
        public string Titulo { get; protected set; }
        public string? Descricao { get; protected set; }
        public DateTime DataCriacao { get; protected set; } = DateTime.UtcNow;

        public Ulid ApoioAggregateId { get; protected set; }
        public AssistenciaAggregate ApoioAggregate { get; protected set; } = null!;
    }
}
