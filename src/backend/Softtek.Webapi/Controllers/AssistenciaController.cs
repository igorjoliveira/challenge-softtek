using Microsoft.AspNetCore.Mvc;
using NUlid;
using Softtek.Application.DTOs;
using Softtek.Application.Interfaces.Services;

namespace Softtek.Webapi.Controllers
{
    [ApiController]
    [Route("api/assistencia")]
    public class AssistenciaController : ControllerBase
    {
        private readonly IAssistenciaService _service;

        public AssistenciaController(IAssistenciaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAssistencia([FromBody] NovaAssistenciaDto dto)
        {
            var codigo = await _service.CriarAssistenciaAsync(dto);
            return CreatedAtAction(nameof(CriarAssistencia), new { codigo }, null);
        }

        [HttpPost("{assistenciaCodigo}/lembretes")]
        public async Task<IActionResult> AdicionarLembrete(Ulid assistenciaCodigo, [FromBody] NovoLembreteDto dto)
        {
            var id = await _service.AdicionarLembreteAsync(assistenciaCodigo, dto);
            return Ok(id);
        }

        [HttpPost("{assistenciaCodigo}/notificacoes")]
        public async Task<IActionResult> AdicionarNotificacao(Ulid assistenciaCodigo, [FromBody] NovaNotificacaoDto dto)
        {
            var id = await _service.AdicionarNotificacaoAsync(assistenciaCodigo, dto);
            return Ok(id);
        }

        [HttpPost("{assistenciaCodigo}/recursos")]
        public async Task<IActionResult> AdicionarRecursoDeApoio(Ulid assistenciaCodigo, [FromBody] NovoRecursoDeApoioDto dto)
        {
            var id = await _service.AdicionarRecursoAsync(assistenciaCodigo, dto);
            return Ok(id);
        }

        [HttpGet("")]
        public async Task<IActionResult> ObterAssistencias()
        {
            var result = await _service.ObterAssistenciasAsync();
            return Ok(result);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> ObterAssistencia(Ulid codigo)
        {
            var result = await _service.ObterAssistenciaAsync(codigo);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet("{codigo}/apoios")]
        public async Task<IActionResult> ObterApoios(Ulid codigo)
        {
            var result = await _service.ObterApoiosAsync(codigo);
            return Ok(result);
        }

        [HttpGet("{codigo}/apoios/por-data")]
        public async Task<IActionResult> ObterApoiosPorData(Ulid codigo, [FromQuery] DateTime data)
        {
            var result = await _service.ObterApoiosPorDataAsync(codigo, data);
            return Ok(result);
        }

        [HttpGet("{codigo}/recursos/{tipo}")]
        public async Task<IActionResult> ObterRecursosPorTipo(Ulid codigo, string tipo)
        {
            var result = await _service.ObterRecursosPorTipoAsync(codigo, tipo);
            return Ok(result);
        }

        [HttpGet("{codigo}/notificacoes/urgentes")]
        public async Task<IActionResult> ObterNotificacoesUrgentes(Ulid codigo)
        {
            var result = await _service.ObterNotificacoesUrgentesAsync(codigo);
            return Ok(result);
        }
    }
}
