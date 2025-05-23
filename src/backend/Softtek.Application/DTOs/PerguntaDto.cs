using NUlid;

namespace Softtek.Application.DTOs
{
    public class PerguntaDto
    {
        public Ulid Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Desativado { get; set; }
        public Ulid EscalaCodigo { get; set; }
        public string EscalaDescricao { get; set; }
        public List<EscalaValorDto> ValoresAceitos { get; set; }
    }

    public record NovaPerguntaDto(
        Ulid BlocoCodigo,
        string Descricao,
        Ulid EscalaCodigo
    );
}
