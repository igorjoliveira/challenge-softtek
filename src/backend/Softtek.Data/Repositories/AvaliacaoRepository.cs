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

        public async Task<int> CriarAvaliacaoAsync(AvaliacaoAggregate avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            return await _context.SaveChangesAsync();
        }

        public async Task<AvaliacaoAggregate?> ObterAvaliacaoPorIdAsync(Ulid avaliacaoCodigo)
        {
            return await _context.Avaliacoes
                .Include(a => a.BlocosDePergunta)
                    .ThenInclude(b => b.Perguntas)                        
                .FirstOrDefaultAsync(a => a.Codigo == avaliacaoCodigo);
        }

        public async Task<IList<AvaliacaoAggregate>> ListarAvaliacoesAsync()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        public async Task<int> AdicionarBlocoAsync(BlocoDePergunta bloco)
        {
            await _context.BlocosDePergunta.AddAsync(bloco);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AdicionarPerguntaAsync(Pergunta pergunta)
        {            
            await _context.Perguntas.AddAsync(pergunta);
            return await _context.SaveChangesAsync();
        }
    }
}
