using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity, TRequestDto, TResponseDto> : ControllerBase
        where TEntity : class, new()
        where TRequestDto : class
        where TResponseDto : class
    {
        private readonly IService<TEntity, TRequestDto, TResponseDto> _service;

        public BaseController(IService<TEntity, TRequestDto, TResponseDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<TResponseDto>>> GetAll(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetPaginatedAsync(pageIndex, pageSize);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TResponseDto>> GetById(long id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Domain.Exceptions.DomainException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TResponseDto>> Create([FromBody] TRequestDto dto)
        {
            try
            {
                var created = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = (created as dynamic).Id }, created);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TResponseDto>> Update(long id, [FromBody] TRequestDto dto)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, dto);
                return Ok(updated);
            }
            catch (Domain.Exceptions.DomainException)
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
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Domain.Exceptions.DomainException)
            {
                return NotFound();
            }
        }
    }
}
