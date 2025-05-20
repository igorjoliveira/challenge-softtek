using NUlid;

namespace Softtek.Domain.Aggregates.MonitoramentoEmocional;

public class RegistroAggregate
{
    public Ulid Codigo { get; set; }
    public required DateOnly DataReferencia { get; set; }

    private readonly List<Questionario> _questionarios = new();
    public IReadOnlyCollection<Questionario> Questionarios => _questionarios.AsReadOnly();

    public void AdicionarQuestionario(Questionario questionario)
    {
        _questionarios.Add(questionario);
    }
    public DateOnly ObterDataUltimoPreenchimento(Ulid blocoCodigo)
    {
        var ultimoQuestionario = _questionarios
            .Where(q => q.BlocoDePerguntaCodigo == blocoCodigo)
            .OrderByDescending(q => q.DataPreenchimento)
            .FirstOrDefault();

        return ultimoQuestionario?.DataPreenchimento ?? DateOnly.MinValue;
    }
}
