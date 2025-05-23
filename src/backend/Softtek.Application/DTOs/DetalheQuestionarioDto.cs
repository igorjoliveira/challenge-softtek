using NUlid;

namespace Softtek.Application.DTOs
{
    public record DetalheQuestionarioDto(
        Ulid Id,
        string Titulo,
        string? Descricao,
        BlocoDePerguntaDto Bloco
    );

    public record BlocoDePerguntaDto(
        Ulid Id,
        string Titulo,
        int Ordem,
        List<PerguntaDto> Perguntas
    );

    public record PerguntaDto(
        Ulid Id,
        string Texto,
        int Ordem,
        List<EscalaValorDto> Valores
    );

    public record EscalaValorDto(
        Ulid Id,
        string Descricao,
        int Valor
    );
}
