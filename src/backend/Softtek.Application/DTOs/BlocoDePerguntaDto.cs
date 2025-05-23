using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Commands;

namespace Softtek.Application.DTOs
{
    public record BlocoDePerguntaDto(
        Ulid Codigo,
        string Titulo,
        FrequenciaDto Frequencia,
        List<PerguntaDto> Perguntas
    );

    public record NovoBlocoDePerguntaDto(
        string titulo, 
        FrequenciaPreenchimento frequencia
    );    
}
