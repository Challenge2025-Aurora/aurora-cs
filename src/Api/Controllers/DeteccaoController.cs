using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Detecções", "Gerencia os registros de detecção de motos capturados por visão computacional ou sensores.")]
    public class DeteccaoController : ControllerBase
    {
        private readonly DeteccaoService _service;

        public DeteccaoController(DeteccaoService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listar detecções", Description = "Retorna todas as detecções cadastradas.")]
        [ProducesResponseType(typeof(List<DeteccaoResponseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DeteccaoResponseDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obter detecção por ID", Description = "Retorna uma detecção específica pelo seu ID.")]
        [ProducesResponseType(typeof(DeteccaoResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeteccaoResponseDto>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Criar detecção", Description = "Registra uma nova detecção no sistema.")]
        [ProducesResponseType(typeof(DeteccaoResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DeteccaoResponseDto>> Create([FromBody] DeteccaoRequestDto dto)
        {
            try
            {
                var created = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar detecção", Description = "Atualiza os dados de uma detecção existente.")]
        [ProducesResponseType(typeof(DeteccaoResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DeteccaoResponseDto>> Update(string id, [FromBody] DeteccaoRequestDto dto)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, dto);
                if (updated is null)
                    return NotFound();

                return Ok(updated);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletar detecção", Description = "Remove uma detecção do sistema.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
