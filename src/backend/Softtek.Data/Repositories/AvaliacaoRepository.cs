using Microsoft.EntityFrameworkCore;
using NUlid;
using Softtek.Data.Context;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Repositories;

namespace Softtek.Data.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly SofttekDbContext _context;

        public AvaliacaoRepository(SofttekDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(AvaliacaoAggregate entidade)
        {
            await _context.Avaliacoes.AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(AvaliacaoAggregate entidade)
        {
            _context.Avaliacoes.Update(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<AvaliacaoAggregate?> ObterPorCodigoAsync(Ulid codigo)
        {
            return await _context.Avaliacoes.Include(a => a.BlocosDePergunta).FirstOrDefaultAsync(a => a.Codigo == codigo);
        }

        public async Task<IEnumerable<AvaliacaoAggregate>> ObterTodosAsync()
        {
            return await _context.Avaliacoes.Include(a => a.BlocosDePergunta).ToListAsync();
        }

        public async Task RemoverAsync(Ulid codigo)
        {
            var avaliacao = await ObterPorCodigoAsync(codigo);
            if (avaliacao != null)
            {
                _context.Avaliacoes.Remove(avaliacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BlocoDePergunta>> ObterBlocosPorFrequenciaAsync(FrequenciaPreenchimento frequencia)
        {
            return await _context.BlocosDePergunta.Where(b => b.Frequencia == frequencia).ToListAsync();
        }

        public async Task<IEnumerable<BlocoDePergunta>> ObterBlocosEmAtrasoAsync()
        {
            return await _context.BlocosDePergunta.Where(b => b.Perguntas.All(p => p.Desativado == false)).ToListAsync();
        }
    }
}
