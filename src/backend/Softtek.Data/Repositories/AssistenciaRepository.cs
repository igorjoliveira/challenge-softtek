using Microsoft.EntityFrameworkCore;
using NUlid;
using Softtek.Data.Context;
using Softtek.Domain.Aggregates.AssistenciaEmocional;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Tipos;

namespace Softtek.Data.Repositories
{
    public class AssistenciaRepository : IAssistenciaRepository
    {
        private readonly SofttekDbContext _context;

        public AssistenciaRepository(SofttekDbContext context)
        {
            _context = context;
        }

        public async Task<int> CriarAssistenciaAsync(AssistenciaAggregate assistencia)
        {
            await _context.Assistencias.AddAsync(assistencia);
            return await _context.SaveChangesAsync();
        }

        public async Task<AssistenciaAggregate?> ObterAssistenciaPorCodigoAsync(Ulid codigo)
        {
            return await _context.Assistencias
                .Include(a => a.Apoios)
                .FirstOrDefaultAsync(a => a.Codigo == codigo);
        }

        public async Task<int> AdicionarLembreteAsync(Lembrete lembrete)
        {
            await _context.Lembretes.AddAsync(lembrete);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AdicionarNotificacaoAsync(Notificacao notificacao)
        {
            await _context.Notificacoes.AddAsync(notificacao);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AdicionarRecursoDeApoioAsync(RecursoDeApoio recurso)
        {
            await _context.RecursosDeApoio.AddAsync(recurso);
            return await _context.SaveChangesAsync();
        }
    }
}
