using NUlid;

namespace Softtek.Domain.Aggregates.MonitoramentoEmocional.Commands
{
    public record struct NovaResposta (Ulid perguntaCodigo, Ulid escalaValorCodigo);
}
