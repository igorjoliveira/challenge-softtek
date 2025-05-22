using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;

namespace Softtek.Domain.Aggregates.MonitoramentoEmocional
{
    public class Resposta
    {
        public required Ulid Codigo { get; set; }

        public required Ulid EscalaValorCodigo { get; set; }
        public EscalaValor EscalaValor { get; set; } = null!;

        public required Ulid PerguntaCodigo { get; set; }
        public Pergunta Pergunta { get; set; } = null!;
    }
}
