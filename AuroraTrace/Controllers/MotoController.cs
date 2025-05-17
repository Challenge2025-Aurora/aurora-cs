using AuroraTrace.Application.DTO;
using AuroraTrace.Domain.Entity;
using AuroraTrace.Domain.Enums;
using AuroraTrace.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuroraTrace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly AuroraTraceContext _context;

        public MotoController(AuroraTraceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoResponseDTO>>> GetAll()
        {
            var motos = await _context.Motos
                .Include(m => m.Patio)
                .Include(m => m.Localizacao)
                .Include(m => m.Funcionario)
                .ToListAsync();

            var response = motos.Select(m => new MotoResponseDTO
            {
                Id = m.Id,
                Placa = m.Placa,
                Modelo = m.Modelo,
                Status = m.Status.ToString(),
                UltimaAtualizacao = m.UltimaAtualizacao,
                PatioId = m.PatioId,
                LocalizacaoId = m.LocalizacaoId,
                FuncionarioId = m.FuncionarioId
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotoResponseDTO>> GetById(long id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            return Ok(new MotoResponseDTO
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Modelo = moto.Modelo,
                Status = moto.Status.ToString(),
                UltimaAtualizacao = moto.UltimaAtualizacao,
                PatioId = moto.PatioId,
                LocalizacaoId = moto.LocalizacaoId,
                FuncionarioId = moto.FuncionarioId
            });
        }

        [HttpGet("porplaca")]
        public async Task<ActionResult<MotoResponseDTO>> GetByPlaca([FromQuery] string placa)
        {
            var moto = await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);
            if (moto == null) return NotFound();

            return Ok(new MotoResponseDTO
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Modelo = moto.Modelo,
                Status = moto.Status.ToString(),
                UltimaAtualizacao = moto.UltimaAtualizacao,
                PatioId = moto.PatioId,
                LocalizacaoId = moto.LocalizacaoId,
                FuncionarioId = moto.FuncionarioId
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MotoRequestDTO dto)
        {
            if (!Enum.TryParse(dto.Status, out StatusMoto status))
                return BadRequest("Status inválido");

            var moto = Moto.Create(dto.Placa, dto.Modelo, status, dto.PatioId, dto.LocalizacaoId, dto.FuncionarioId);

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = moto.Id }, moto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] MotoRequestDTO dto)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            if (!Enum.TryParse(dto.Status, out StatusMoto status))
                return BadRequest("Status inválido");

            var updatedMoto = Moto.Create(dto.Placa, dto.Modelo, status, dto.PatioId, dto.LocalizacaoId, dto.FuncionarioId);

            _context.Entry(moto).CurrentValues.SetValues(updatedMoto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
