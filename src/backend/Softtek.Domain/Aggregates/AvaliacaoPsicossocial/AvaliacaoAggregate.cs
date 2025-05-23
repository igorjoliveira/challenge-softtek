using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Commands;

namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

public class AvaliacaoAggregate(DateOnly dataCriacao)
{
    private readonly List<BlocoDePergunta> _blocosDePergunta = new();

    public Ulid Codigo { get; private set; } = Ulid.NewUlid();
    public DateOnly DataCriacao { get; private set; } = dataCriacao;    
    public IReadOnlyCollection<BlocoDePergunta> BlocosDePergunta => _blocosDePergunta.AsReadOnly();

    public BlocoDePergunta AdicionarBloco(NovoBlocoDePergunta bloco)
    {
        var blocoPergunta = new BlocoDePergunta(Codigo, bloco);

        if (_blocosDePergunta.Any(b => b.GetHashCode() == bloco.GetHashCode()))
            throw new InvalidOperationException($"Bloco {bloco.titulo} já existe na avaliação.");
        
        _blocosDePergunta.Add(blocoPergunta);
        return blocoPergunta;
    }
    public List<BlocoDePergunta> ObterBlocosParaNotificacao(FrequenciaPreenchimento frequencia)
    {
        return _blocosDePergunta.Where(b => b.Frequencia == frequencia).ToList();
    }
    public IEnumerable<BlocoDePergunta> ObterBlocosPendentes(DateOnly dataReferencia)
    {
        return _blocosDePergunta.Where(b => !b.Perguntas.Any() ||
                                            b.Perguntas.All(p => p.Desativado == true));
    }
    public IEnumerable<BlocoDePergunta> ObterBlocosEmAtraso()
    {
        return _blocosDePergunta.Where(b => b.Frequencia == FrequenciaPreenchimento.Diario && b.Perguntas.All(p => p.Desativado == false));
    }
    public BlocoDePergunta? ObterBloco(Ulid blocoCodigo)
    => BlocosDePergunta.FirstOrDefault(b => b.Codigo == blocoCodigo);
}
