using NUlid;

namespace Softtek.Application.DTOs
{
    public record NovoQuestionarioDto(
        Ulid BlocoDeRespostaId,
        List<NovaRespostaDto> respostas
    );

    public record NovaRespostaDto(
        Ulid PerguntaId,
        Ulid EscalaValorId
    );

    public record RespostaDto(
        PerguntaDto Pergunta,
        EscalaValorDto EscalaValor
    );
}
