using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/[controller]")]
[SwaggerTag("Setores", "Gerencia os setores dos p�tios, onde as motos s�o posicionadas.")]
public class SetorController : ControllerBase
{
    private readonly SetorService _service;

    public SetorController(SetorService service)
    {
        _service = service;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Listar setores", Description = "Retorna todos os setores dentro dos p�tios.")]
    [ProducesResponseType(typeof(List<SetorResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<SetorResponseDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obter setor por ID", Description = "Retorna um setor espec�fico pelo seu ID.")]
    [ProducesResponseType(typeof(SetorResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SetorResponseDto>> GetById(string id)
    {
        var result = await _service.GetByIdAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Criar setor", Description = "Registra um novo setor em um p�tio.")]
    [ProducesResponseType(typeof(SetorResponseDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<SetorResponseDto>> Create([FromBody] SetorRequestDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualizar setor", Description = "Atualiza as informa��es de um setor.")]
    [ProducesResponseType(typeof(SetorResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SetorResponseDto>> Update(string id, [FromBody] SetorRequestDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletar setor", Description = "Remove um setor do sistema.")]
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
