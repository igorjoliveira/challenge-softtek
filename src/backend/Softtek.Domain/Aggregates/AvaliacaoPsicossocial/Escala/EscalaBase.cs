using NUlid;

namespace Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala
{
    public abstract class EscalaBase
    {
        private readonly List<EscalaBaseValor> _valoresAceitos = new();

        public Ulid Codigo { get; private set; } = Ulid.NewUlid();
        public string Descricao { get; private set; }
        public IReadOnlyCollection<EscalaBaseValor> ValoresAceitos => _valoresAceitos.AsReadOnly();

        protected EscalaBase(string descricao)
        {
            Descricao = descricao;
        }

        public abstract string InterpretarMedia(decimal media);
        public virtual string ObterSignificado(string resultado) { return string.Empty; }
        public virtual void AdicionarValorAceito(params EscalaValor[] valoresAceitos)
        {
            if (valoresAceitos is null)
                throw new ArgumentNullException(nameof(valoresAceitos));

            foreach (var valor in valoresAceitos)
            {
                if (_valoresAceitos.Any(v => v.EscalaValorCodigo == valor.Codigo))
                    throw new InvalidOperationException($"O valor {valor.Descricao} já existe na escala.");

                _valoresAceitos.Add(new EscalaBaseValor(Codigo, valor.Codigo));
            }
        }
    }
}
