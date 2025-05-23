using NUlid;
using Softtek.Domain.Aggregates.MonitoramentoEmocional.Commands;

namespace Softtek.Domain.Aggregates.MonitoramentoEmocional;

public class RegistroAggregate ()
{
    private readonly List<Questionario> _questionarios = new();
    public IReadOnlyCollection<Questionario> Questionarios => _questionarios.AsReadOnly();

    public Ulid AdicionarQuestionario(NovoQuestionario novoQuestionario)
    {
        if(_questionarios.Any(x => x.BlocoDePerguntaCodigo == novoQuestionario.blocoDePerguntaCodigo))
            throw new InvalidOperationException($"Já existe um questionário preenchido para o bloco de perguntas {novoQuestionario.blocoDePerguntaCodigo}.");

        var questionario = new Questionario(novoQuestionario.dataPreenchimento, novoQuestionario.blocoDePerguntaCodigo);
        _questionarios.Add(questionario);

        return questionario.Codigo;
    }
    public Questionario ObterQuestionario(Ulid blocoCodigo)
    {
        var questionario = _questionarios
            .FirstOrDefault(q => q.BlocoDePerguntaCodigo == blocoCodigo);

        if (questionario == null)
            throw new InvalidOperationException($"Não foi encontrado um questionário preenchido para o bloco de perguntas {blocoCodigo}.");

        return questionario;
    }
    public DateOnly ObterDataUltimoPreenchimento(Ulid blocoCodigo)
    {
        var ultimoQuestionario = _questionarios
            .Where(q => q.BlocoDePerguntaCodigo == blocoCodigo)
            .OrderByDescending(q => q.DataPreenchimento)
            .FirstOrDefault();

        return ultimoQuestionario?.DataPreenchimento ?? DateOnly.MinValue;
    }
    public bool VerificarPreenchimentoCompleto(Ulid blocoCodigo)
    {
        var questionario = _questionarios.FirstOrDefault(q => q.BlocoDePerguntaCodigo == blocoCodigo);
        return questionario?.Respostas.Count > 0;
    }
    public IEnumerable<Resposta> ObterRespostasPorData(DateOnly dataPreenchimento)
    {
        return _questionarios
               .Where(q => q.DataPreenchimento == dataPreenchimento)
               .SelectMany(q => q.Respostas);
    }
}
