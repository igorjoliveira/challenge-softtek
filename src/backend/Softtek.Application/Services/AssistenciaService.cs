using AutoMapper;
using NUlid;
using Softtek.Application.DTOs;
using Softtek.Application.Interfaces.Services;
using Softtek.Domain.Aggregates.AssistenciaEmocional;
using Softtek.Domain.Aggregates.AssistenciaEmocional.Commands;
using Softtek.Domain.Exceptions;

namespace Softtek.Application.Services
{
    public class AssistenciaService : IAssistenciaService
    {
        private readonly IAssistenciaRepository _repository;
        private readonly IMapper _mapper;

        public AssistenciaService(IAssistenciaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Ulid> CriarAssistenciaAsync(NovaAssistenciaDto dto)
        {
            var assistencia = new AssistenciaAggregate();
            await _repository.CriarAssistenciaAsync(assistencia);
            return assistencia.Codigo;
        }
        public async Task<Ulid> AdicionarLembreteAsync(Ulid assistenciaCodigo, NovoLembreteDto dto)
        {
            var assistencia = await _repository.ObterAssistenciaPorCodigoAsync(assistenciaCodigo)
                ?? throw new NotFoundException("Assistência não encontrada.");

            var comando = new NovoLembrete(dto.Titulo, dto.Mensagem, dto.DataAgendada);
            var lembrete = assistencia.CriarLembrete(comando);
            await _repository.AdicionarLembreteAsync(lembrete);
            return lembrete.Codigo;
        }
        public async Task<Ulid> AdicionarNotificacaoAsync(Ulid assistenciaCodigo, NovaNotificacaoDto dto)
        {
            var assistencia = await _repository.ObterAssistenciaPorCodigoAsync(assistenciaCodigo)
                ?? throw new NotFoundException("Assistência não encontrada.");

            var comando = new NovaNotificacao(dto.Titulo, dto.Conteudo, dto.Urgente);
            var notificacao = assistencia.CriarNotificacao(comando);
            await _repository.AdicionarNotificacaoAsync(notificacao);
            return notificacao.Codigo;
        }
        public async Task<Ulid> AdicionarRecursoAsync(Ulid assistenciaCodigo, NovoRecursoDeApoioDto dto)
        {
            var assistencia = await _repository.ObterAssistenciaPorCodigoAsync(assistenciaCodigo)
                ?? throw new NotFoundException("Assistência não encontrada.");

            var comando = new NovoRecursoDeApoio(dto.Titulo, dto.Link, (TipoRecurso)dto.TipoRecurso, dto.Categoria);
            var recurso = assistencia.CriarRecursoDeApoio(comando);
            await _repository.AdicionarRecursoDeApoioAsync(recurso);
            return recurso.Codigo;
        }
        public async Task<AssistenciaDto?> ObterAssistenciaAsync(Ulid codigo)
        {
            var assistencia = await _repository.ObterAssistenciaPorCodigoAsync(codigo);
            if (assistencia is null) return null;

            var dto = _mapper.Map<AssistenciaDto>(assistencia);
            dto.Apoios = assistencia.Apoios.Select(_mapper.Map<ApoioDto>).ToList();
            return dto;
        }
        public async Task<IEnumerable<ApoioDto>> ObterApoiosAsync(Ulid codigo)
        {
            var assistencia = await _repository.ObterAssistenciaPorCodigoAsync(codigo)
                ?? throw new NotFoundException("Assistência não encontrada.");

            return assistencia.Apoios.Select(_mapper.Map<ApoioDto>);
        }
        public async Task<IEnumerable<ApoioDto>> ObterApoiosPorDataAsync(Ulid codigo, DateTime data)
        {
            var assistencia = await _repository.ObterAssistenciaPorCodigoAsync(codigo)
                ?? throw new NotFoundException("Assistência não encontrada.");

            var apoios = assistencia.ObterApoiosPorData(data);
            return apoios.Select(_mapper.Map<ApoioDto>);
        }
        public async Task<IEnumerable<ApoioDto>> ObterRecursosPorTipoAsync(Ulid codigo, string tipo)
        {
            var assistencia = await _repository.ObterAssistenciaPorCodigoAsync(codigo)
                ?? throw new NotFoundException("Assistência não encontrada.");

            if (!Enum.TryParse<TipoRecurso>(tipo, out var tipoRecurso))
                throw new ArgumentException("Tipo de recurso inválido.");

            var recursos = assistencia.ObterApoiosPorTipo(tipoRecurso);
            return recursos.Select(_mapper.Map<ApoioDto>);
        }
        public async Task<IEnumerable<ApoioDto>> ObterNotificacoesUrgentesAsync(Ulid codigo)
        {
            var assistencia = await _repository.ObterAssistenciaPorCodigoAsync(codigo)
                ?? throw new NotFoundException("Assistência não encontrada.");

            var urgentes = assistencia.ObterNotificacoesUrgentes();
            return urgentes.Select(_mapper.Map<ApoioDto>);
        }
    }
}
