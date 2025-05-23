using NUlid;

namespace Softtek.Application.DTOs
{
    public class AvaliacaoDto
    {
        public Ulid Codigo { get; set; }
        public DateOnly DataCriacao { get; set; }
        public List<BlocoDePerguntaDto> Blocos { get; set; } = new List<BlocoDePerguntaDto>();
    }
}
