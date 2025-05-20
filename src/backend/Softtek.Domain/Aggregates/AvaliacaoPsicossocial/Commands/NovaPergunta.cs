using NUlid;

namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Commands
{
    public record struct NovaPergunta(string descricao, Ulid escalaCodigo);
}
