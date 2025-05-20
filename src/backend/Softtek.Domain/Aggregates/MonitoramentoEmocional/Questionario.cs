using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

namespace Softtek.Domain.Aggregates.MonitoramentoEmocional
{
    public class Questionario
    {
        private readonly List<Resposta> _respostas = new();

        public Ulid Codigo { get; set; }
        public required DateOnly DataPreenchimento { get; set; }

        public required Ulid BlocoDePerguntaCodigo { get; set; }
        public required BlocoDePergunta BlocoDePergunta { get; set; }
        
        public IReadOnlyCollection<Resposta> Respostas => _respostas.AsReadOnly();

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
