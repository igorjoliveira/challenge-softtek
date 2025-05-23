namespace Softtek.Application.DTOs
{
    public class NovaNotificacaoDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Conteudo { get; set; } = string.Empty;
        public bool Urgente { get; set; }
    }
}
