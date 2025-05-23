using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Commands;

namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial
{
    public class BlocoDePergunta
    {
        private readonly List<Pergunta> _perguntas = new();

        public Ulid Codigo { get; private set; } = Ulid.NewUlid();
        public string Titulo { get; private set; }
        public FrequenciaPreenchimento Frequencia { get; private set; }
        public Ulid AvaliacaoCodigo { get; private set; }
        public AvaliacaoAggregate Avaliacao { get; set; } = null!;
        public IReadOnlyCollection<Pergunta> Perguntas => _perguntas.AsReadOnly();

        private BlocoDePergunta() { }
        public BlocoDePergunta(Ulid avaliacaoCodigo, NovoBlocoDePergunta bloco)
        {
            Codigo = Ulid.NewUlid();
            AvaliacaoCodigo = avaliacaoCodigo;
            Titulo = bloco.titulo;
            Frequencia = bloco.frequencia;
        }

        public Pergunta AdicionarPergunta(NovaPergunta novaPergunta)
        {            
            var pergunta = new Pergunta(Codigo, novaPergunta);

            if (_perguntas.Any(q => q.Descricao == novaPergunta.descricao))
                throw new InvalidOperationException($"A pergunta '{novaPergunta.descricao}' já existe no bloco de perguntas.");

            _perguntas.Add(pergunta);
            return pergunta;
        }
        public void RemoverPergunta(Ulid perguntaId)
        {
            _perguntas.RemoveAll(p => p.Codigo == perguntaId);
        }

        public override int GetHashCode()
        {
            return $"{Titulo}-{Frequencia}".ToUpper().GetHashCode();
        }
    }
}
