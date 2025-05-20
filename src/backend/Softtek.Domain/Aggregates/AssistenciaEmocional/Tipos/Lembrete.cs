using NUlid;

namespace Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos
{
    public class Lembrete : ApoioBase
    {
        public DateTime DataAgendada { get; private set; }

        public Lembrete(string titulo, string descricao, DateTime dataAgendada)
        {
            Codigo = Ulid.NewUlid();
            Titulo = titulo;
            Descricao = descricao;
            DataAgendada = dataAgendada;
        }
    }
}
