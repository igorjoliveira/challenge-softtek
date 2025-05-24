using NUlid;
using Softtek.Application.DTOs;

namespace Softtek.Application.Interfaces.Services
{
    public interface IRegistroService
    {
        Task<Ulid> CriarAvaliacaoAsync(NovaAvaliacaoDto dto);
        Task<Ulid> AdicionarBlocoAsync(Ulid avaliacaoCodigo, NovoBlocoDePerguntaDto dto);
        Task<IList<Ulid>> AdicionarPerguntaAsync(Ulid avaliacaoCodigo, Ulid blocoCodigo, params NovaPerguntaDto[] dtos);
        Task<IList<AvaliacaoDto>> ListarAvaliacoesAsync();
        Task<IList<BlocoDePerguntaDto>> ObterBlocosPorAvaliacaoAsync(Ulid avaliacaoCodigo);
        Task<IList<PerguntaDto>> ObterPerguntasPorBlocoAsync(Ulid avaliacaoCodigo, Ulid blocoCodigo);
    }
}
