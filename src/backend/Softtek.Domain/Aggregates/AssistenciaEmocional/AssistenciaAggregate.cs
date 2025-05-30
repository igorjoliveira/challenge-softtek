﻿using NUlid;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Commands;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

namespace Softtek.Domain.Aggregates.AssistenciaEmocional
{
    public class AssistenciaAggregate
    {
        private readonly List<ApoioBase> _apoios = new();
        public Ulid Codigo { get; private set; } = Ulid.NewUlid();        
        public IReadOnlyCollection<ApoioBase> Apoios => _apoios.AsReadOnly();

        private void AdicionarApoio(ApoioBase apoio)
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
        public IEnumerable<ApoioBase> ObterApoiosPorData(DateTime data)
        {
            return _apoios.Where(a => a.DataCriacao.Date == data.Date ||
                                      (a is Lembrete l && l.DataAgendada.Date == data.Date));
        }
        public IEnumerable<RecursoDeApoio> ObterApoiosPorTipo(TipoRecurso tipo)
        {
            return _apoios.OfType<RecursoDeApoio>().Where(r => r.Tipo == tipo);
        }
        public IEnumerable<Notificacao> ObterNotificacoesUrgentes()
        {
            return _apoios.OfType<Notificacao>().Where(n => n.Urgente);
        }
        public Lembrete CriarLembrete(NovoLembrete comando)
        {
            var lembrete = new Lembrete(comando.Titulo, comando.Descricao, comando.DataAgendada);
            AdicionarApoio(lembrete);
            return lembrete;
        }

        public Notificacao CriarNotificacao(NovaNotificacao comando)
        {
            var notificacao = new Notificacao(comando.Titulo, comando.Descricao, comando.Urgente, comando.NivelGravidade);
            AdicionarApoio(notificacao);
            return notificacao;
        }

        public RecursoDeApoio CriarRecursoDeApoio(NovoRecursoDeApoio comando)
        {
            var recurso = new RecursoDeApoio(comando.Titulo, comando.Link, comando.Tipo, comando.Categoria);
            AdicionarApoio(recurso);
            return recurso;
        }

    }
}
