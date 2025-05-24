using Microsoft.EntityFrameworkCore;
using NUlid;
using Softtek.Data.Context;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;

public class RegistroRepository : IRegistroRepository
{
    private readonly SofttekDbContext _context;

    public RegistroRepository(SofttekDbContext context)
    {
        _context = context;
    }

    public async Task<List<Questionario>> ObterTodosQuestionariosAsync()
    {
        return await _context.Questionarios
            .Include(q => q.BlocoDePergunta)
                .ThenInclude(b => b.Perguntas)
            .ToListAsync();
    }

    public async Task<Questionario?> ObterQuestionarioPorIdAsync(Ulid codigo)
    {
        return await _context.Questionarios
            .Include(q => q.BlocoDePergunta)
                .ThenInclude(b => b.Perguntas)
            .FirstOrDefaultAsync(q => q.Codigo == codigo);
    }

    public async Task<Questionario?> ObterQuestionarioPorDataAsync(DateOnly dataPreenchimento)
    {
        return await _context.Questionarios
            .Include(q => q.BlocoDePergunta)
                .ThenInclude(b => b.Perguntas)
            .FirstOrDefaultAsync(q => q.DataPreenchimento == dataPreenchimento);
    }

    public async Task<int> AdicionarRespostaAsync(Resposta resposta)
    {
        await _context.Respostas.AddAsync(resposta);
        return await _context.SaveChangesAsync();
    }
}
