namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala.Tipos
{
    public class IntensidadeEscala(string descricao) : EscalaBase(descricao)
    {
        public override string InterpretarMedia(decimal media)
        {
            return media switch
            {
                >= 21 and <= 40 => "Leve",
                >= 41 and <= 60 => "Média",
                >= 61 and <= 80 => "Alta",
                >= 81 and <= 100 => "Muito Alta",
                _ => "Muito Leve"
            };
        }
    }
}