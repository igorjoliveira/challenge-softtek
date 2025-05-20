using Microsoft.EntityFrameworkCore;
using NUlid;
using Softtek.Data.Context;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;
using Softtek.Domain.Repositories;

namespace Softtek.Data.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly SofttekDbContext _context;

        public RegistroRepository(SofttekDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(RegistroAggregate entidade)
        {
            throw new NotImplementedException();
        }

        public async Task AtualizarAsync(RegistroAggregate entidade)
        {
            throw new NotImplementedException();
        }

        public async Task<RegistroAggregate?> ObterPorCodigoAsync(Ulid codigo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RegistroAggregate>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoverAsync(Ulid codigo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Questionario>> ObterQuestionariosPorDataAsync(DateOnly dataPreenchimento)
        {
            return await _context.Questionarios.Where(q => q.DataPreenchimento == dataPreenchimento).ToListAsync();
        }

        public async Task<IEnumerable<Resposta>> ObterRespostasPorDataAsync(DateOnly dataPreenchimento)
        {
            return await _context.Questionarios.Include(x => x.BlocoDePergunta)
                                  .Include(x => x.Respostas)
                                  .ThenInclude(x => x.Pergunta)
                                  .Where(x => x.DataPreenchimento == dataPreenchimento)
                                  .SelectMany(x => x.Respostas)
                                  .ToListAsync();
        }
    }
}
