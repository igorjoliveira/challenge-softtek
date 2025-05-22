using Microsoft.AspNetCore.Mvc;
using NUlid;
using Softtek.Application.Interfaces.Services;

namespace Softtek.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpPost("iniciar")]
        public async Task<IActionResult> IniciarAvaliacao(DateOnly dataCriacao)
        {
            var codigo = await _avaliacaoService.IniciarAvaliacaoAsync(dataCriacao);
            return Ok(new { Codigo = codigo.ToString() });
        }

        [HttpGet("{codigo}/blocos-pendentes")]
        public async Task<IActionResult> ObterBlocosPendentes(Ulid codigo)
        {
            var blocosPendentes = await _avaliacaoService.ObterBlocosPendentesAsync(codigo);
            return Ok(blocosPendentes);
        }

        [HttpPost("{questionarioCodigo}/resposta")]
        public async Task<IActionResult> AdicionarResposta(Ulid questionarioCodigo, Ulid perguntaCodigo, Ulid escalaValorCodigo)
        {
            await _avaliacaoService.AdicionarRespostaAsync(questionarioCodigo, perguntaCodigo, escalaValorCodigo);
            return Ok();
        }
    }
}
