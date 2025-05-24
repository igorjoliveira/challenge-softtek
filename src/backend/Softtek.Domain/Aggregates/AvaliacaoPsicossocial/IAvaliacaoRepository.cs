using NUlid;

namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial
{
    public interface IAvaliacaoRepository
    {
        Task<int> CriarAvaliacaoAsync(AvaliacaoAggregate avaliacao);
        Task<AvaliacaoAggregate?> ObterAvaliacaoPorIdAsync(Ulid avaliacaoCodigo);
        Task<IList<AvaliacaoAggregate>> ListarAvaliacoesAsync();
        Task<int> AdicionarBlocoAsync(BlocoDePergunta bloco);
        Task<int> AdicionarPerguntaAsync(Pergunta pergunta);
    }
}
