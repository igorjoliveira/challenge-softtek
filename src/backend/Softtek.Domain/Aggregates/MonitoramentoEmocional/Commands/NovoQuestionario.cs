using NUlid;

namespace Softtek.Domain.Aggregates.MonitoramentoEmocional.Commands
{
    public record struct NovoQuestionario (DateOnly dataPreenchimento, Ulid blocoDePerguntaCodigo);
}
