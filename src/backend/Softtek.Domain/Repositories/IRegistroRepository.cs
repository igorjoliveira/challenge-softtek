using NUlid;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;

namespace Softtek.Domain.Repositories
{
    public interface IRegistroRepository
    {
        Task AdicionarAsync(RegistroAggregate entidade);
        Task AtualizarAsync(RegistroAggregate entidade);
        Task<RegistroAggregate?> ObterPorCodigoAsync(Ulid codigo);
        Task<IEnumerable<RegistroAggregate>> ObterTodosAsync();
        Task RemoverAsync(Ulid codigo);
        Task<IEnumerable<Questionario>> ObterQuestionariosPorDataAsync(DateOnly dataPreenchimento);
        Task<IEnumerable<Resposta>> ObterRespostasPorDataAsync(DateOnly dataPreenchimento);
    }
}
