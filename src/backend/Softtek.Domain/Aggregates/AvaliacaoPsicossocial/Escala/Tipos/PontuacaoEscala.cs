namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala.Tipos
{
    public class PontuacaoEscala(string descricao) : EscalaBase(descricao)
    {
        public override string InterpretarMedia(decimal media)
        {
            return media switch
            {
                >= 1 and <= 2.4M => "Atenção",
                >= 2.5M and <= 3.4M => "Zona de Alerta",
                _ => "Ambiente Saudável"
            };
        }
    }
}
