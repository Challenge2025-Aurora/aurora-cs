using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/[controller]")]
[SwaggerTag("Gerencia os pátios utilizados na operação da Mottu.")]
public class PatioController : ControllerBase
{
    private readonly PatioService _service;

    public PatioController(PatioService service)
    {
        _service = service;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Listar pátios", Description = "Retorna todos os pátios registrados.")]
    [ProducesResponseType(typeof(List<PatioResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PatioResponseDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter pátio por ID", Description = "Retorna um pátio específico pelo seu ID.")]
    [ProducesResponseType(typeof(PatioResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatioResponseDto>> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [Authorize]
    [HttpPost]
    [SwaggerOperation(Summary = "Criar pátio", Description = "Registra um novo pátio no sistema.")]
    [ProducesResponseType(typeof(PatioResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PatioResponseDto>> Create([FromBody] PatioRequestDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [Authorize]
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar pátio", Description = "Atualiza as informações de um pátio.")]
    [ProducesResponseType(typeof(PatioResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatioResponseDto>> Update(string id, [FromBody] PatioRequestDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }

    [Authorize]
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletar pátio", Description = "Remove um pátio do sistema.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(string id)
    {
        var found = await _service.GetByIdAsync(id);
        if (found is null) return NotFound();

        await _service.DeleteAsync(id);
        return NoContent();
    }
}
