using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Controlador base genérico para operações CRUD (Create, Read, Update, Delete) com paginação e links HATEOAS.
    /// </summary>
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

        /// <summary>
        /// Retorna todos os recursos paginados.
        /// </summary>
        /// <param name="pageIndex">O número da página a ser retornada (padrão é 1).</param>
        /// <param name="pageSize">O número de itens por página (padrão é 10).</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>
        /// Retorna um recurso pelo ID.
        /// </summary>
        /// <param name="id">O ID do recurso.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Cria um novo recurso.
        /// </summary>
        /// <param name="dto">O objeto de requisição com os dados para criação.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Atualiza um recurso existente pelo ID.
        /// </summary>
        /// <param name="id">O ID do recurso a ser atualizado.</param>
        /// <param name="dto">O objeto de requisição com os novos dados.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Remove um recurso pelo ID.
        /// </summary>
        /// <param name="id">O ID do recurso a ser deletado.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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