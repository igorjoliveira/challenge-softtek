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

        public void AdicionarPergunta(params NovaPergunta[] perguntas)
        {
            if (perguntas is null)
                throw new ArgumentNullException(nameof(perguntas));

            foreach (var pergunta in perguntas)
            {
                if (_perguntas.Any(q => q.Descricao == pergunta.descricao))
                    throw new InvalidOperationException($"A pergunta '{pergunta.descricao}' já existe no bloco de perguntas.");

                _perguntas.Add(new Pergunta(Codigo, pergunta));
            }
        }
        public void RemoverPergunta(Ulid perguntaId)
        {
            _perguntas.RemoveAll(p => p.Codigo == perguntaId);
        }
    }
}
