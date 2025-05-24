using NUlid;

namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;

public class EscalaValor
{
    private readonly List<EscalaBase> _escalasAssociadas = new();
    public Ulid Codigo { get; private set; } = Ulid.NewUlid();
    public string Descricao { get; private set; }    
    public IReadOnlyCollection<EscalaBase> EscalasAssociadas => _escalasAssociadas.AsReadOnly();

    public EscalaValor(string descricao)
    {
        Descricao = descricao;
    }

    public void AssociarEscala(EscalaBase escala)
    {
        if (!_escalasAssociadas.Contains(escala))
        {
            _escalasAssociadas.Add(escala);
        }
    }
}
