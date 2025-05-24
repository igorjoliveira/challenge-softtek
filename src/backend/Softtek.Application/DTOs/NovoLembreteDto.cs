using System;

namespace Softtek.Application.DTOs
{
    public class NovoLembreteDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataAgendada { get; set; }
    }
}
