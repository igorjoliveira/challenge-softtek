using NUlid;
using Softtek.Application.DTOs;

namespace Softtek.Application.Interfaces.Services
{
    public interface IAvaliacaoService
    {
        Task<Ulid> IniciarAvaliacaoAsync(DateOnly dataCriacao);
        Task<IEnumerable<BlocoDePerguntaDto>> ObterBlocosPendentesAsync(Ulid avaliacaoCodigo);
        Task AdicionarRespostaAsync(Ulid questionarioCodigo, Ulid perguntaCodigo, Ulid escalaValorCodigo);
    }
}
