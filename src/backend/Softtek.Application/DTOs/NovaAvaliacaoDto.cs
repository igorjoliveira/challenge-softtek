using NUlid;

namespace Softtek.Application.DTOs
{
    public record NovaAvaliacaoDto(
        DateOnly DataCriacao,
        List<BlocoDePerguntaDto> Blocos
    );
}
