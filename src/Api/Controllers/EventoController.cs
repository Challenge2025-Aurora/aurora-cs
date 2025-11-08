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
[SwaggerTag("Gerencia os eventos gerados no sistema, como movimentações e registros de atividades.")]
public class EventoController : ControllerBase
{
    private readonly EventoService _service;

    public EventoController(EventoService service)
    {
        _service = service;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Listar eventos", Description = "Retorna todos os eventos registrados no sistema.")]
    [ProducesResponseType(typeof(List<EventoResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<EventoResponseDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter evento por ID", Description = "Retorna um evento específico pelo seu ID.")]
    [ProducesResponseType(typeof(EventoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventoResponseDto>> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [Authorize]
    [HttpPost]
    [SwaggerOperation(Summary = "Criar evento", Description = "Registra um novo evento no sistema.")]
    [ProducesResponseType(typeof(EventoResponseDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<EventoResponseDto>> Create([FromBody] EventoRequestDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [Authorize]
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar evento", Description = "Atualiza os dados de um evento existente.")]
    [ProducesResponseType(typeof(EventoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EventoResponseDto>> Update(string id, [FromBody] EventoRequestDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }

    [Authorize]
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletar evento", Description = "Remove um evento do sistema.")]
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
