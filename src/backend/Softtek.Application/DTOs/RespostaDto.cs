using NUlid;

namespace Softtek.Application.DTOs
{
    public record RespostaDto(
        Ulid PerguntaId,
        Ulid EscalaValorId
    );
}
