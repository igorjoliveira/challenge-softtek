namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala.Tipos
{
    public class EmocaoEscala(string descricao) : EscalaBase(descricao)
    {
        public override string ObterSignificado(string resultado)
        {
            return resultado.ToLower() switch
            {
                "Leve" => "Episódios que geram essas emoções e pensamentos que não necessariamente tenham impacto em suas atividades, mas ocasionalmente afetam seu bem-estar.",
                "Moderado" => "Sentimento persistente que afeta a motivação e o bem-estar, podendo influenciar o humor por dias e semanas.",
                "Agudo" => "Sentimento intenso e profundo acompanhado que podem desencadear ou não sentimentos correlacionados, afetando a qualidade de seus relacionamentos, suas ocupações, qualidade de vida e bem-estar.",
                _ => "Neutro"
            };
        }

        public override string InterpretarMedia(decimal media)
        {
            return media switch
            {
                >= 26 and <= 50 => "Leve",
                >= 51 and <= 75 => "Moderado",
                >= 76 and <= 100 => "Agudo",
                _ => "Neutro"
            };
        }
    }
}
