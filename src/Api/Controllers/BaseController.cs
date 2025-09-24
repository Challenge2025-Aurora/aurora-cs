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

            foreach (var item in result.Items)
            {
                TryAddLinks(item);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TResponseDto>> GetById(long id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                TryAddLinks(result, id);
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

                if (created is not null)
                    TryAddLinks(created, (created as dynamic).Id);

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
                TryAddLinks(updated, id);
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

        protected List<LinkDto> GenerateLinks(long id)
        {
            var entityName = typeof(TEntity).Name.ToLower();
            return new List<LinkDto>
            {
                new LinkDto($"/api/{entityName}s/{id}", "self", "GET"),
                new LinkDto($"/api/{entityName}s/{id}", "update", "PUT"),
                new LinkDto($"/api/{entityName}s/{id}", "delete", "DELETE")
            };
        }

        private void TryAddLinks(object dto, long? id = null)
        {
            if (dto is null) return;

            var dtoType = dto.GetType();
            var linksProp = dtoType.GetProperty("Links");

            if (linksProp != null && linksProp.PropertyType == typeof(List<LinkDto>))
            {
                var resolvedId = id ?? (long)(dtoType.GetProperty("Id")?.GetValue(dto) ?? 0);
                linksProp.SetValue(dto, GenerateLinks(resolvedId));
            }
        }
    }
}
