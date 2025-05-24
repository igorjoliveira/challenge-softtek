using Microsoft.AspNetCore.Mvc;
using NUlid;
using Softtek.Application.DTOs;
using Softtek.Application.Interfaces.Services;

[ApiController]
[Route("api/[controller]")]
public class AvaliacaoController : ControllerBase
{
    private readonly IAvaliacaoService _service;

    public AvaliacaoController(IAvaliacaoService service)
    {
        _service = service;
    }

    [HttpGet("questionarios")]
    public async Task<IActionResult> ListarQuestionarios()
    {
        var result = await _service.ListarQuestionariosAsync();
        return Ok(result);
    }

    [HttpGet("questionarios/{codigoQuestionario}")]
    public async Task<IActionResult> ObterQuestionario(Ulid codigoQuestionario)
    {
        var result = await _service.ObterQuestionarioAsync(codigoQuestionario);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost("questionarios/{dataPreenchimento}/respostas")]
    public async Task<IActionResult> AdicionarResposta(DateOnly dataPreenchimento, [FromBody] NovoQuestionarioDto dto)
    {
        await _service.EnviarRespostaAsync(dataPreenchimento, dto);
        return Created();
    }
}
