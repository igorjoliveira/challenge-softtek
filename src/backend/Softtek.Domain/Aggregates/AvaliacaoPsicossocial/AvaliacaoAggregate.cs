using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Commands;

namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

public class AvaliacaoAggregate(DateOnly dataCriacao)
{
    private readonly List<BlocoDePergunta> _blocosDePergunta = new();

    public Ulid Codigo { get; private set; } = Ulid.NewUlid();
    public DateOnly DataCriacao { get; private set; } = dataCriacao;    
    public IReadOnlyCollection<BlocoDePergunta> BlocosDePergunta => _blocosDePergunta.AsReadOnly();

    public void AdicionarBloco(params NovoBlocoDePergunta[] blocos)
    {
        foreach (var bloco in blocos)
        {
            if (_blocosDePergunta.Any(b => b.Titulo == bloco.titulo))
                throw new InvalidOperationException($"Bloco {bloco.titulo} já existe na avaliação.");
            _blocosDePergunta.Add(new BlocoDePergunta(Codigo, bloco));
        }
    }
    public List<BlocoDePergunta> ObterBlocosParaNotificacao(FrequenciaPreenchimento frequencia)
    {
        return _blocosDePergunta.Where(b => b.Frequencia == frequencia).ToList();
    }
}
