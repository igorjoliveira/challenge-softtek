using NUlid;

namespace Softtek.Application.DTOs
{
    public record BlocoDePerguntaDto(
        Ulid Codigo,
        string Titulo,
        FrequenciaDto Frequencia,
        List<PerguntaDto> Perguntas
    );
}
