using AutoMapper;
using NUlid;
using Softtek.Application.DTOs;
using Softtek.Application.Interfaces.Services;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Commands;
using Softtek.Domain.Exceptions;

namespace Softtek.Application.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IMapper _mapper;

        public RegistroService(IAvaliacaoRepository avaliacaoRepository, IMapper mapper)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _mapper = mapper;
        }
        public async Task<Ulid> CriarAvaliacaoAsync(NovaAvaliacaoDto dto)
        {
            var avaliacao = new AvaliacaoAggregate(dto.DataCriacao);
            if (await _avaliacaoRepository.CriarAvaliacaoAsync(avaliacao) > 0)
                return avaliacao.Codigo;

            throw new Exception("Erro ao criar avaliação");
        }
        public async Task<Ulid> AdicionarBlocoAsync(Ulid avaliacaoCodigo, NovoBlocoDePerguntaDto dto)
        {
            var avaliacao = await _avaliacaoRepository.ObterAvaliacaoPorIdAsync(avaliacaoCodigo);
            if (avaliacao == null) 
                throw new NotFoundException("Avaliação não encontrada");

            var bloco = avaliacao.AdicionarBloco(new NovoBlocoDePergunta(dto.titulo, dto.frequencia));
            
            if (await _avaliacaoRepository.AdicionarBlocoAsync(bloco) > 0)
                return bloco.Codigo;

            throw new Exception("Erro ao adicionar bloco de perguntas");
        }
        public async Task<IList<Ulid>> AdicionarPerguntaAsync(Ulid avaliacaoCodigo, Ulid blocoCodigo, params NovaPerguntaDto[] dtos)
        {
            var avaliacao = await _avaliacaoRepository.ObterAvaliacaoPorIdAsync(avaliacaoCodigo);
            if (avaliacao == null)
                throw new NotFoundException("Avaliação não encontrada");

            var result = new List<Ulid>();

            foreach (var dto in dtos)
            {
                if (!avaliacao.BlocosDePergunta.Any(b => b.Codigo == blocoCodigo))
                    throw new NotFoundException("Bloco de perguntas não encontrado");

                var bloco = avaliacao.ObterBloco(dto.BlocoCodigo);
                var pergunta = bloco.AdicionarPergunta(new NovaPergunta(dto.Descricao, dto.EscalaCodigo));
                await _avaliacaoRepository.AdicionarPerguntaAsync(pergunta);

                result.Add(pergunta.Codigo);
            }

            return result;
        }
        public async Task<IList<AvaliacaoDto>> ListarAvaliacoesAsync()
        {
            var avaliacoes = await _avaliacaoRepository.ListarAvaliacoesAsync();
            return _mapper.Map<List<AvaliacaoDto>>(avaliacoes);
        }
        public async Task<IList<BlocoDePerguntaDto>> ObterBlocosPorAvaliacaoAsync(Ulid avaliacaoCodigo)
        {
            var avaliacao = await _avaliacaoRepository.ObterAvaliacaoPorIdAsync(avaliacaoCodigo);
            if (avaliacao == null) 
                throw new NotFoundException("Avaliação não encontrada.");

            return _mapper.Map<List<BlocoDePerguntaDto>>(avaliacao.BlocosDePergunta);
        }
        public async Task<IList<PerguntaDto>> ObterPerguntasPorBlocoAsync(Ulid avaliacaoCodigo, Ulid blocoCodigo)
        {
            var avaliacao = await _avaliacaoRepository.ObterAvaliacaoPorIdAsync(avaliacaoCodigo);
            if (avaliacao == null) throw new NotFoundException("Avaliação não encontrada.");

            var bloco = avaliacao.ObterBloco(blocoCodigo);
            if (bloco == null) throw new NotFoundException("Bloco não encontrado.");

            return _mapper.Map<List<PerguntaDto>>(bloco.Perguntas);
        }
    }
}
