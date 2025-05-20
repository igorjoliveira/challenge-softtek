using NUlid;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

namespace Softtek.Domain.Aggregates.AssistenciaEmocional
{
    public class AssistenciaAggregate
    {
        private readonly List<ApoioBase> _apoios = new();
        public Ulid Codigo { get; private set; }        
        public IReadOnlyCollection<ApoioBase> Apoios => _apoios.AsReadOnly();

        public void AdicionarApoio(ApoioBase apoio)
        {
            _apoios.Add(apoio);
        }
        public void VerificarFrequenciaBloco(BlocoDePergunta bloco, DateOnly ultimaDataPreenchimento)
        {
            var hoje = DateOnly.FromDateTime(DateTime.UtcNow);

            bool criarNotificacao = false;
            string mensagem = string.Empty;

            switch (bloco.Frequencia)
            {
                case FrequenciaPreenchimento.Diario:
                    criarNotificacao = (hoje > ultimaDataPreenchimento);
                    mensagem = $"Você não preencheu o bloco '{bloco.Titulo}' hoje.";
                    break;
                case FrequenciaPreenchimento.Semanal:
                    criarNotificacao = (hoje.DayNumber - ultimaDataPreenchimento.DayNumber >= 7);
                    mensagem = $"Já se passou uma semana desde o último preenchimento do bloco '{bloco.Titulo}'.";
                    break;
                case FrequenciaPreenchimento.Mensal:
                    criarNotificacao = (hoje.Month != ultimaDataPreenchimento.Month);
                    mensagem = $"O bloco '{bloco.Titulo}' não foi preenchido neste mês.";
                    break;
                case FrequenciaPreenchimento.Semestral:
                    criarNotificacao = (hoje.Month - ultimaDataPreenchimento.Month >= 6);
                    mensagem = $"O bloco '{bloco.Titulo}' não foi preenchido no semestre atual.";
                    break;
                case FrequenciaPreenchimento.Anual:
                    criarNotificacao = (hoje.Year != ultimaDataPreenchimento.Year);
                    mensagem = $"Já se passou um ano desde o último preenchimento do bloco '{bloco.Titulo}'.";
                    break;
            }

            if (criarNotificacao)
            {
                var notificacao = new Notificacao(
                    titulo: "Preenchimento em atraso",
                    descricao: mensagem,
                    urgente: true
                );

                AdicionarApoio(notificacao);
            }
        }
    }
}
