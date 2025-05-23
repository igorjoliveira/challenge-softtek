using NUlid;
using Softtek.Application.DTOs;

namespace Softtek.Application.Interfaces.Services
{
    public interface IAvaliacaoService
    {
        Task<List<QuestionarioDto>> ListarQuestionariosAsync();
        Task<DetalheQuestionarioDto?> ObterQuestionarioAsync(Ulid id);
        Task<Ulid> EnviarRespostaAsync(Ulid codigoQuestionario, NovaRespostaDto dto);
    }

}
