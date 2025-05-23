using NUlid;

namespace Softtek.Application.DTOs
{
    public record QuestionarioDto(
        Ulid Id,
        string Titulo,
        string? Descricao
    );
}
