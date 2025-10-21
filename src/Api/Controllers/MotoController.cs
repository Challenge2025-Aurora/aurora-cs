using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/[controller]")]
[SwaggerTag("Motos", "Gerencia o cadastro, localização e status das motos no sistema.")]
public class MotoController : ControllerBase
{
    private readonly MotoService _service;

    public MotoController(MotoService service)
    {
        _service = service;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Listar motos", Description = "Retorna todas as motos cadastradas.")]
    [ProducesResponseType(typeof(List<MotoResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MotoResponseDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter moto por ID", Description = "Retorna uma moto específica pelo seu ID.")]
    [ProducesResponseType(typeof(MotoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MotoResponseDto>> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Criar moto", Description = "Cria uma nova moto no sistema.")]
    [ProducesResponseType(typeof(MotoResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MotoResponseDto>> Create([FromBody] MotoRequestDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar moto", Description = "Atualiza os dados de uma moto existente.")]
    [ProducesResponseType(typeof(MotoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MotoResponseDto>> Update(string id, [FromBody] MotoRequestDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletar moto", Description = "Remove uma moto do sistema pelo ID.")]
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
