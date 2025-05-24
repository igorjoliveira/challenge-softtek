using NUlid;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;

public interface IRegistroRepository
{
    Task<List<Questionario>> ObterTodosQuestionariosAsync();
    Task<Questionario?> ObterQuestionarioPorIdAsync(Ulid codigo);
    Task<Questionario?> ObterQuestionarioPorDataAsync(DateOnly dataPreenchimento);
    Task<int> AdicionarRespostaAsync(Resposta resposta);
    Task<int> AdicionarQuestionarioAsync(Questionario questionario);
}
