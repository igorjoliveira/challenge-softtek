namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala.Tipos
{
    public class FrequenciaEscala(string descricao) : EscalaBase(descricao)
    {
        public override string InterpretarMedia(decimal media)
        {
            return media switch
            {
                >= 21 and <= 40 => "Raramente",
                >= 41 and <= 60 => "Às vezes",
                >= 61 and <= 80 => "Frequentemente",
                >= 81 and <= 100 => "Sempre",
                _ => "Não"
            };
        }
    }
}
