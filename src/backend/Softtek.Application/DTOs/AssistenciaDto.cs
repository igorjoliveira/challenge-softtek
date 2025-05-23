using NUlid;
using Softtek.Application.DTOs;

namespace Softtek.Application.DTOs
{
    public class AssistenciaDto
    {
        public Ulid Codigo { get; set; }
        public List<ApoioDto> Apoios { get; set; } = new();
    }
}
