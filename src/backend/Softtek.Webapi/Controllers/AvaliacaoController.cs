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
    public async Task<IActionResult> GetQuestionarios()
    {
        var result = await _service.ListarQuestionariosAsync();
        return Ok(result);
    }

    [HttpGet("questionarios/{codigoQuestionario}")]
    public async Task<IActionResult> GetQuestionario(Ulid codigoQuestionario)
    {
        var result = await _service.ObterQuestionarioAsync(codigoQuestionario);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost("{codigoQuestionario}/respostas")]
    public async Task<IActionResult> PostResposta(Ulid codigoQuestionario, [FromBody] RespostaDto dto)
    {
        await _service.EnviarRespostaAsync(codigoQuestionario, dto);
        return Created();
    }

}
