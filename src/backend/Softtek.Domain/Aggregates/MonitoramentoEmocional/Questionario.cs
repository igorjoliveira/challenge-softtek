using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.MonitoramentoEmocional.Commands;

namespace Softtek.Domain.Aggregates.MonitoramentoEmocional
{
    public class Questionario
    {
        private readonly List<Resposta> _respostas = new();

        public Ulid Codigo { get; private set; }
        public DateOnly DataPreenchimento { get; private set; }

        public Ulid BlocoDePerguntaCodigo { get; private set; }
        public BlocoDePergunta BlocoDePergunta { get; private set; }
        
        public IReadOnlyCollection<Resposta> Respostas => _respostas.AsReadOnly();

        private Questionario() { }
        public Questionario(DateOnly dataPreenchimento, Ulid blocoDePerguntaCodigo)
        {
            Codigo = Ulid.NewUlid();
            DataPreenchimento = dataPreenchimento;
            BlocoDePerguntaCodigo = blocoDePerguntaCodigo;
        }

        public Resposta AdicionarResposta(NovaResposta record)
        {
            var resposta = new Resposta(record.perguntaCodigo, record.escalaValorCodigo);

            if (_respostas.Any(r => r.GetHashCode() == resposta.GetHashCode()))
                throw new InvalidOperationException($"A pergunta já possui uma resposta registrada.");

            _respostas.Add(resposta);
            return resposta;
        }
    }
}
