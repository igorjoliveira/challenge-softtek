using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

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

        public void AdicionarResposta(Resposta resposta)
        {
            if (resposta == null)
                throw new ArgumentNullException(nameof(resposta));
            else if (_respostas.Any(r => r.Codigo == resposta.Codigo))
                throw new InvalidOperationException($"A resposta com o código {resposta.Codigo} já existe no questionário.");

            _respostas.Add(resposta);
        }
    }
}
