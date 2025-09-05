using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoService _motoService;

        public MotoController(IMotoService motoService)
        {
            _motoService = motoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoResponseDTO>>> GetAll()
        {
            var motos = await _motoService.GetAllAsync();
            return Ok(motos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotoResponseDTO>> GetById(long id)
        {
            try
            {
                var moto = await _motoService.GetByIdAsync(id);
                return Ok(moto);
            }
            catch (DomainException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MotoRequestDTO dto)
        {
            try
            {
                var moto = await _motoService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = moto.Id }, moto);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] MotoRequestDTO dto)
        {
            try
            {
                var moto = await _motoService.UpdateAsync(id, dto);
                return Ok(moto);
            }
            catch (DomainException)
            {
                return NotFound();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _motoService.DeleteAsync(id);
                return NoContent();
            }
            catch (DomainException)
            {
                return NotFound();
            }
        }
    }
}
