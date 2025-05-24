using AutoMapper;
using NUlid;
using Softtek.Application.DTOs;
using Softtek.Application.Interfaces.Services;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;
using Softtek.Domain.Aggregates.MonitoramentoEmocional.Commands;
using Softtek.Domain.Exceptions;

namespace Softtek.Application.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IRegistroRepository _repository;
        private readonly IMapper _mapper;

        public AvaliacaoService(IRegistroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        
        public async Task<List<QuestionarioDto>> ListarQuestionariosAsync()
        {
            var questionarios = await _repository.ObterTodosQuestionariosAsync();
            return _mapper.Map<List<QuestionarioDto>>(questionarios);
        }
        public async Task<DetalheQuestionarioDto?> ObterQuestionarioAsync(Ulid id)
        {
            var questionario = await _repository.ObterQuestionarioPorIdAsync(id);
            return questionario is null ? null : _mapper.Map<DetalheQuestionarioDto>(questionario);
        }
        public async Task<Ulid> EnviarRespostaAsync(DateOnly dataPreenchimento, NovoQuestionarioDto dto)
        {
            var result = 0;
            var questionario = await _repository.ObterQuestionarioPorDataAsync(dataPreenchimento);

            if (questionario is null)
            {
                questionario = new Questionario(dataPreenchimento, dto.BlocoDeRespostaId);
                result = await _repository.AdicionarQuestionarioAsync(questionario);
                if (result == 0)
                {
                    throw new Exception("Erro ao adicionar questionário.");
                }
            }   

            foreach (var respostaDto in dto.respostas)
            {
                var resposta = questionario.AdicionarResposta(new NovaResposta(respostaDto.EscalaValorId, respostaDto.PerguntaId));
                result = await _repository.AdicionarRespostaAsync(resposta);

                if (result == 0)
                {
                    throw new Exception("Erro ao adicionar resposta.");
                }
            }

            return questionario.Codigo;
        }
    }
}
