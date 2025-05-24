using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Commands;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;

namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial
{
    public class Pergunta
    {
        public Ulid Codigo { get; set; } = Ulid.NewUlid();
        public string Descricao { get; set; }
        public bool? Desativado { get; set; }

        public Ulid EscalaCodigo { get; set; }
        public EscalaBase Escala { get; set; } = null!;

        public Ulid BlocoDePerguntaCodigo { get; set; }
        public BlocoDePergunta Bloco { get; set; } = null!;
        
        private Pergunta() { }
        public Pergunta(Ulid blocoDePerguntaCodigo, NovaPergunta novaPergunta)
        {
            Codigo = Ulid.NewUlid();
            BlocoDePerguntaCodigo = blocoDePerguntaCodigo;
            Descricao = novaPergunta.descricao;
            EscalaCodigo = novaPergunta.escalaCodigo;
        }
    }    
}
