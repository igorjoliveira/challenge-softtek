using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Commands;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala.Tipos;

namespace Softtek.Domain
{
    internal class Program
    {
        void main(string[] args)
        {
            var avaliacao = new AvaliacaoAggregate(DateOnly.FromDateTime(DateTime.Now));
            avaliacao.AdicionarBloco(
                new NovoBlocoDePergunta("Mapeamento de Riscos - Ansiedade/Depressão/Burnout", FrequenciaPreenchimento.Diario),
                new NovoBlocoDePergunta("Fatores de Carga de Trabalho", FrequenciaPreenchimento.Mensal),
                new NovoBlocoDePergunta("Sinais de Alerta", FrequenciaPreenchimento.Mensal),
                new NovoBlocoDePergunta("Diagnóstico de Clima - Relacionamento", FrequenciaPreenchimento.Mensal),
                new NovoBlocoDePergunta("Comunicação", FrequenciaPreenchimento.Mensal),
                new NovoBlocoDePergunta("Relação com a Liderança", FrequenciaPreenchimento.Mensal));

            var valoresAceitos = new List<EscalaValor>
            {
                new("Triste"),
                new("Alegre"),
                new("Cansado"),
                new("Ansioso"),
                new("Medo"),
                new("Raiva"),
                new("Motivado"),
                new("Cansado"),
                new("Preocupado"),
                new("Estressado"),
                new("Animado"),
                new("Satisfeito"),
                new("Muito Leve"),
                new("Leve"),
                new("Média"),
                new("Alta"),
                new("Muito Alta"),
                new("Não"),
                new("Raramente"),
                new("Às vezes"),
                new("Frequentemente"),
                new("Sempre"),
                new("1"),
                new("2"),
                new("3"),
                new("4"),
                new("5")
            };

            var emocaoEscala = new EmocaoEscala("Uso: diário emocional");
            emocaoEscala.AdicionarValorAceito([.. valoresAceitos.Take(6)]);

            var humorEscala = new HumorEscala("Uso: bem-estar geral");
            humorEscala.AdicionarValorAceito([.. valoresAceitos.Skip(6).Take(6)]);

            var intensidadeEscala = new IntensidadeEscala("Uso: percepção de impacto");
            intensidadeEscala.AdicionarValorAceito([.. valoresAceitos.Skip(12).Take(5)]);

            var frequenciaEscala = new FrequenciaEscala("Uso: comportamentos");
            frequenciaEscala.AdicionarValorAceito([.. valoresAceitos.Skip(17).Take(5)]);

            var pontuacaoEscala = new PontuacaoEscala("Uso: questionários");
            pontuacaoEscala.AdicionarValorAceito([.. valoresAceitos.Skip(23)]);

            var perguntas = new List<NovaPergunta>()
            {
                new NovaPergunta ("Escolha o seu emoji de hoje!", emocaoEscala.Codigo),
                new NovaPergunta ("Como você se sente hoje?", humorEscala.Codigo),
                new NovaPergunta ("Como você avalia sua carga de trabalho?", intensidadeEscala.Codigo),
                new NovaPergunta ("Sua carga de trabalho afeta sua qualidade de vida?", frequenciaEscala.Codigo),
                new NovaPergunta ("Você trabalha além do seu horário regular?", frequenciaEscala.Codigo),
                new NovaPergunta ("Você tem apresentado sintomas como insônia, irritabilidade ou cansaço extremo?", frequenciaEscala.Codigo),
                new NovaPergunta ("Você sente que sua saúde mental prejudica sua produtividade no trabalho?", frequenciaEscala.Codigo),
                new NovaPergunta ("Como está o seu relacionamento com seu chefe numa escala de 1 a 5? (Sendo 01 - ruim e 05 - Ótimo)", pontuacaoEscala.Codigo),
                new NovaPergunta ("Como está o seu relacionamento com seus colegas de trabalho numa escala de 1 a 5? (Sendo 01 - ruim e 05 - Ótimo)", pontuacaoEscala.Codigo),
                new NovaPergunta ("Sinto que sou tratado(a) com respeito pelos meus colegas de trabalho.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Consigo me relacionar de forma saudável e colaborativa com minha equipe.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Tenho liberdade para expressar minhas opiniões sem medo de retaliações.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Me sinto acolhido(a) a parte do time onde trabalho.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Sinto que existe espírito de cooperação entre os colaboradores.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Recebo orientações claras e objetivas sobre minhas atividades e responsabilidades.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Sinto que posso me comunicar abertamente com minha liderança.", pontuacaoEscala.Codigo),
                new NovaPergunta ("As informações importantes circulam de forma eficiente dentro da empresa.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Tenho clareza sobre as metas e os resultados esperados de mim.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Minha liderança demonstra interesse pelo meu bem-estar no trabalho.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Minha liderança está disponível para me ouvir quando necessário.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Me sinto confortável para reportar problemas ou dificuldades ao meu líder.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Minha liderança reconhece minhas entregas e esforços.", pontuacaoEscala.Codigo),
                new NovaPergunta ("Existe confiança e transparência na relação com minha liderança.", pontuacaoEscala.Codigo)
            };

            var perguntasPorBloco = new Dictionary<string, int[]>(StringComparer.OrdinalIgnoreCase)
            {
                ["Mapeamento de Riscos - Ansiedade/Depressão/Burnout"] = [0, 1],
                ["Fatores de Carga de Trabalho"] = [2, 3, 4],
                ["Sinais de Alerta"] = [5, 6],
                ["Diagnóstico de Clima - Relacionamento"] = [7, 8, 9, 10, 11, 12, 13],
                ["Comunicação"] = [14, 15, 16, 17],
                ["Relação com a Liderança"] = [18, 19, 20, 21, 22]
            };

            foreach (var bloco in avaliacao.BlocosDePergunta)
            {
                if (perguntasPorBloco.TryGetValue(bloco.Titulo, out var indices))
                {
                    bloco.AdicionarPergunta(indices.Select(i => perguntas[i]).ToArray());
                }
            }
        }
    }
}