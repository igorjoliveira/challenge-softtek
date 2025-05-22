using NUlid;

namespace Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos
{
    public class Notificacao : ApoioBase
    {
        public string? NivelGravidade { get; set; }
        public bool Urgente { get; private set; }

        private Notificacao() { }
        public Notificacao(string titulo, string descricao, bool urgente = false, string? nivelGravidade = null)
        {
            Codigo = Ulid.NewUlid();
            Titulo = titulo;
            Descricao = descricao;
            Urgente = urgente;
            NivelGravidade = nivelGravidade;
        }

        public void MarcarComoUrgente()
        {
            Urgente = true;
        }
    }
}
