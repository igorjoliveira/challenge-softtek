using AutoMapper;
using NUlid;
using Softtek.Application.DTOs;
using Softtek.Application.Interfaces.Services;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;
using Softtek.Domain.Repositories;

namespace Softtek.Application.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IRegistroRepository _registroRepository;
        private readonly IMapper _mapper;

        public AvaliacaoService(
            IAvaliacaoRepository avaliacaoRepository,
            IRegistroRepository registroRepository,
            IMapper mapper)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _registroRepository = registroRepository;
            _mapper = mapper;
        }

        public async Task<Ulid> IniciarAvaliacaoAsync(DateOnly dataCriacao)
        {
            var avaliacao = new AvaliacaoAggregate(dataCriacao);
            await _avaliacaoRepository.AdicionarAsync(avaliacao);
            return avaliacao.Codigo;
        }

        public async Task<IEnumerable<BlocoDePerguntaDto>> ObterBlocosPendentesAsync(Ulid avaliacaoCodigo)
        {
            var avaliacao = await _avaliacaoRepository.ObterPorCodigoAsync(avaliacaoCodigo);
            if (avaliacao == null) return Enumerable.Empty<BlocoDePerguntaDto>();

            var blocosPendentes = avaliacao.ObterBlocosPendentes(DateOnly.FromDateTime(DateTime.Now));
            return _mapper.Map<IEnumerable<BlocoDePerguntaDto>>(blocosPendentes);
        }

        public async Task AdicionarRespostaAsync(Ulid questionarioCodigo, Ulid perguntaCodigo, Ulid escalaValorCodigo)
        {
            var registro = (await _registroRepository.ObterTodosAsync())
                                .FirstOrDefault(r => r.Questionarios.Any(q => q.Codigo == questionarioCodigo));

            if (registro == null)
                throw new Exception("Questionário não encontrado.");

            var questionario = registro.ObterQuestionario(questionarioCodigo);
            var resposta = new Resposta
            {
                Codigo = Ulid.NewUlid(),
                PerguntaCodigo = perguntaCodigo,
                EscalaValorCodigo = escalaValorCodigo
            };

            questionario.AdicionarResposta(resposta);
            await _registroRepository.AtualizarAsync(registro);
        }
    }
}
