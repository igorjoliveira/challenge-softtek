using NUlid;

namespace Softtek.Application.DTOs
{
    public record CriarAvaliacaoDto(
        Ulid Codigo,
        DateOnly DataCriacao,
        List<BlocoDePerguntaDto> Blocos
    );
}
