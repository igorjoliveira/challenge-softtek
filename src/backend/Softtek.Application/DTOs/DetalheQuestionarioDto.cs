using NUlid;

namespace Softtek.Application.DTOs
{
    public record DetalheQuestionarioDto(
        Ulid Id,
        string Titulo,
        string? Descricao,
        BlocoDePerguntaDto Bloco
    );
}
