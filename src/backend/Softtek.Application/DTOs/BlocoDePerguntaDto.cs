using NUlid;

namespace Softtek.Application.DTOs
{
    public class BlocoDePerguntaDto
    {
        public Ulid Codigo { get; set; }
        public string Titulo { get; set; }
        public bool? Desativado { get; set; }
    }
}
