using NUlid;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos;

namespace Softtek.Domain.Aggregates.AssistenciaEmocional
{
    public interface IAssistenciaRepository
    {
        Task<int> CriarAssistenciaAsync(AssistenciaAggregate assistencia);
        Task<IList<AssistenciaAggregate>> ObterAssistenciasAsync();
        Task<AssistenciaAggregate?> ObterAssistenciaPorCodigoAsync(Ulid codigo);
        Task<int> AdicionarLembreteAsync(Lembrete lembrete);
        Task<int> AdicionarNotificacaoAsync(Notificacao notificacao);
        Task<int> AdicionarRecursoDeApoioAsync(RecursoDeApoio recurso);
    }
}
