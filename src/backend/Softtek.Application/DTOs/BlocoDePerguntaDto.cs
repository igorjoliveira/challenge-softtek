using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

namespace Softtek.Application.DTOs
{
    public class BlocoDePerguntaDto
    {
        public Ulid Codigo { get; set; }
        public string Titulo {get; set;}
        public FrequenciaDto Frequencia {get; set;}
        public List<PerguntaDto> Perguntas {get; set;}
    }

    public record NovoBlocoDePerguntaDto(
        string titulo, 
        FrequenciaPreenchimento frequencia
    );    
}
