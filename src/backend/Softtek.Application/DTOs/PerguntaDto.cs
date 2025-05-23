using NUlid;

namespace Softtek.Application.DTOs
{
    public record PerguntaDto(
        Ulid Codigo,
        string Descricao,
        bool Desativado,
        Ulid EscalaCodigo,
        string EscalaDescricao,        
        List<EscalaValorDto> ValoresAceitos
    );
}
