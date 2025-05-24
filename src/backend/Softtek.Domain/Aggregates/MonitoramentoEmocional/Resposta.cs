using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;

namespace Softtek.Domain.Aggregates.MonitoramentoEmocional
{
    public class Resposta
    {
        public Ulid Codigo { get; set; }

        public Ulid QuestionarioCodigo { get; set; }
        public Questionario Questionario { get; set; } = null!;

        public Ulid EscalaValorCodigo { get; set; }
        public EscalaValor EscalaValor { get; set; } = null!;

        public Ulid PerguntaCodigo { get; set; }
        public Pergunta Pergunta { get; set; } = null!;

        public Resposta(Ulid questionarioCodigo, Ulid escalaValorCodigo, Ulid perguntaCodigo)
        {
            Codigo = Ulid.NewUlid();
            QuestionarioCodigo = questionarioCodigo;
            EscalaValorCodigo = escalaValorCodigo;
            PerguntaCodigo = perguntaCodigo;
        }

        public override int GetHashCode()
        {
            return $"{PerguntaCodigo}-{EscalaValorCodigo}".GetHashCode();
        }
    }
}
