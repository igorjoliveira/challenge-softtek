using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

namespace Softtek.Domain.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task AdicionarAsync(AvaliacaoAggregate entidade);
        Task AtualizarAsync(AvaliacaoAggregate entidade);
        Task<AvaliacaoAggregate?> ObterPorCodigoAsync(Ulid codigo);
        Task<IEnumerable<AvaliacaoAggregate>> ObterTodosAsync();
        Task RemoverAsync(Ulid codigo);
        Task<IEnumerable<BlocoDePergunta>> ObterBlocosPorFrequenciaAsync(FrequenciaPreenchimento frequencia);
        Task<IEnumerable<BlocoDePergunta>> ObterBlocosEmAtrasoAsync();
    }
}
