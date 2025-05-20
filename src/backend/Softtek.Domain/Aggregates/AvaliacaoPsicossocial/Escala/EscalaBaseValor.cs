using NUlid;

namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;

public class EscalaBaseValor
{
    public Ulid EscalaBaseCodigo { get; private set; }
    public EscalaBase EscalaBase { get; private set; } = null!;

    public Ulid EscalaValorCodigo { get; private set; }
    public EscalaValor EscalaValor { get; private set; } = null!;

    public EscalaBaseValor(Ulid escalaBaseCodigo, Ulid escalaValorCodigo)
    {
        EscalaBaseCodigo = escalaBaseCodigo;
        EscalaValorCodigo = escalaValorCodigo;
    }
}
