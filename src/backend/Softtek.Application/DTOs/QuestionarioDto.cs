using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;

namespace Softtek.Application.DTOs
{
    public record QuestionarioDto(
        Ulid Codigo,
        DateOnly DataPreenchimento,
        BlocoDePergunta BlocoDePergunta,
        List<RespostaDto> Respostas
    );
}
