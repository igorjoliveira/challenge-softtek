using NUlid;
using Softtek.Application.DTOs;

namespace Softtek.Application.Interfaces.Services
{
    public interface IAssistenciaService
    {
        Task<Ulid> CriarAssistenciaAsync(NovaAssistenciaDto dto);
        Task<Ulid> AdicionarLembreteAsync(Ulid assistenciaCodigo, NovoLembreteDto dto);
        Task<Ulid> AdicionarNotificacaoAsync(Ulid assistenciaCodigo, NovaNotificacaoDto dto);
        Task<Ulid> AdicionarRecursoAsync(Ulid assistenciaCodigo, NovoRecursoDeApoioDto dto);
        Task<IEnumerable<AssistenciaDto>> ObterAssistenciasAsync();
        Task<AssistenciaDto?> ObterAssistenciaAsync(Ulid codigo);
        Task<IEnumerable<ApoioDto>> ObterApoiosAsync(Ulid codigo);
        Task<IEnumerable<ApoioDto>> ObterApoiosPorDataAsync(Ulid codigo, DateTime data);
        Task<IEnumerable<ApoioDto>> ObterRecursosPorTipoAsync(Ulid codigo, string tipo);
        Task<IEnumerable<ApoioDto>> ObterNotificacoesUrgentesAsync(Ulid codigo);
    }
}
