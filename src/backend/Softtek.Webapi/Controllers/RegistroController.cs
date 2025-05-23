using Microsoft.AspNetCore.Mvc;
using NUlid;
using Softtek.Application.DTOs;
using Softtek.Application.Interfaces.Services;

namespace Softtek.Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroService _service;

        public RegistroController(IRegistroService service)
        {
            _service = service;
        }

        [HttpPost("avaliacoes")]
        public async Task<IActionResult> CriarAvaliacao([FromBody] NovaAvaliacaoDto dto)
        {
            var codigo = await _service.CriarAvaliacaoAsync(dto);
            return CreatedAtAction(nameof(CriarAvaliacao), new { codigo }, null);
        }

        [HttpPost("avaliacoes/{avaliacaoCodigo}/blocos")]
        public async Task<IActionResult> AdicionarBloco(Ulid avaliacaoCodigo, [FromBody] NovoBlocoDePerguntaDto dto)
        {
            var codigo = await _service.AdicionarBlocoAsync(avaliacaoCodigo, dto);
            return Ok(codigo);
        }

        [HttpPost("avaliacoes/{avaliacaoCodigo}/blocos/{blocoCodigo}/perguntas")]
        public async Task<IActionResult> AdicionarPergunta(Ulid avaliacaoCodigo, Ulid blocoCodigo, [FromBody] NovaPerguntaDto dto)
        {
            var codigos = await _service.AdicionarPerguntaAsync(avaliacaoCodigo, blocoCodigo, dto);
            return Ok(codigos);
        }

        [HttpGet("avaliacoes")]
        public async Task<IActionResult> ListarAvaliacoes()
        {
            var result = await _service.ListarAvaliacoesAsync();
            return Ok(result);
        }

        [HttpGet("avaliacoes/{avaliacaoCodigo}/blocos")]
        public async Task<IActionResult> ObterBlocosPorAvaliacao(Ulid avaliacaoCodigo)
        {
            var result = await _service.ObterBlocosPorAvaliacaoAsync(avaliacaoCodigo);
            return Ok(result);
        }

        [HttpGet("avaliacoes/{avaliacaoCodigo}/blocos/{blocoCodigo}/perguntas")]
        public async Task<IActionResult> ObterPerguntasPorBloco(Ulid avaliacaoCodigo, Ulid blocoCodigo)
        {
            var result = await _service.ObterPerguntasPorBlocoAsync(avaliacaoCodigo, blocoCodigo);
            return Ok(result);
        }
    }
}
