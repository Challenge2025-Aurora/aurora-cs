using AuroraTrace.Application.DTOs.Request;
using AuroraTrace.Application.DTOs.Response;
using AuroraTrace.Domain.Entity;
using AuroraTrace.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuroraTrace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly AuroraTraceContext _context;

        public FuncionarioController(AuroraTraceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioResponseDto>>> GetAll()
        {
            var funcionarios = await _context.Funcionarios.ToListAsync();

            var response = funcionarios.Select(f => new FuncionarioResponseDto
            {
                Id = f.Id,
                Nome = f.Nome,
                Matricula = f.Matricula,
                Cargo = f.Cargo,
                Telefone = f.Telefone
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioResponseDto>> GetById(long id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return NotFound();

            var response = new FuncionarioResponseDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Matricula = funcionario.Matricula,
                Cargo = funcionario.Cargo,
                Telefone = funcionario.Telefone
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create(FuncionarioRequestDto dto)
        {
            var funcionario = Funcionario.Create(dto.Nome, dto.Matricula, dto.Cargo, dto.Telefone);

            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = funcionario.Id }, funcionario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, FuncionarioRequestDto dto)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return NotFound();

            var atualizado = Funcionario.Create(dto.Nome, dto.Matricula, dto.Cargo, dto.Telefone);

            _context.Entry(funcionario).CurrentValues.SetValues(atualizado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return NotFound();

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
