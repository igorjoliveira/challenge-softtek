using NUlid;

namespace Softtek.Application.DTOs
{
    public class ApoioDto
    {
        public Ulid Codigo { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
    }
}
