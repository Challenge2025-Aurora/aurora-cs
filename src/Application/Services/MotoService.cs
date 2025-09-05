using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using Domain.Enum;
using Domain.Exceptions;
using Infrastructure.Context;

namespace Application.Services
{
    public interface IMotoService
    {
        Task<MotoResponseDTO> CreateAsync(MotoRequestDTO dto);
        Task<MotoResponseDTO> UpdateAsync(long id, MotoRequestDTO dto);
        Task DeleteAsync(long id);
        Task<IEnumerable<MotoResponseDTO>> GetAllAsync();
        Task<MotoResponseDTO> GetByIdAsync(long id);
    }

    public class MotoService : IMotoService
    {
        private readonly AuroraTraceContext _context;

        public MotoService(AuroraTraceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MotoResponseDTO>> GetAllAsync()
        {
            var motos = await _context.Motos
                .Include(m => m.Patio)
                .Include(m => m.Localizacao)
                .Include(m => m.Funcionario)
                .ToListAsync();

            return motos.Select(m => new MotoResponseDTO
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
        }

        public async Task<MotoResponseDTO> GetByIdAsync(long id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                throw new DomainException("Moto não encontrada.");

            return new MotoResponseDTO
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Modelo = moto.Modelo,
                Status = moto.Status.ToString(),
                UltimaAtualizacao = moto.UltimaAtualizacao,
                PatioId = moto.PatioId,
                LocalizacaoId = moto.LocalizacaoId,
                FuncionarioId = moto.FuncionarioId
            };
        }

        public async Task<MotoResponseDTO> CreateAsync(MotoRequestDTO dto)
        {
            if (!Enum.TryParse(dto.Status, out StatusMoto status))
                throw new ArgumentException("Status inválido.");

            var moto = Moto.Create(dto.Placa, dto.Modelo, status, dto.PatioId, dto.LocalizacaoId, dto.FuncionarioId);
            await _context.Motos.AddAsync(moto);
            await _context.SaveChangesAsync();

            return new MotoResponseDTO
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Modelo = moto.Modelo,
                Status = moto.Status.ToString(),
                UltimaAtualizacao = moto.UltimaAtualizacao,
                PatioId = moto.PatioId,
                LocalizacaoId = moto.LocalizacaoId,
                FuncionarioId = moto.FuncionarioId
            };
        }

        public async Task<MotoResponseDTO> UpdateAsync(long id, MotoRequestDTO dto)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                throw new DomainException("Moto não encontrada.");

            if (!Enum.TryParse(dto.Status, out StatusMoto status))
                throw new ArgumentException("Status inválido.");

            var updatedMoto = Moto.Create(dto.Placa, dto.Modelo, status, dto.PatioId, dto.LocalizacaoId, dto.FuncionarioId);
            _context.Entry(moto).CurrentValues.SetValues(updatedMoto);
            await _context.SaveChangesAsync();

            return new MotoResponseDTO
            {
                Id = updatedMoto.Id,
                Placa = updatedMoto.Placa,
                Modelo = updatedMoto.Modelo,
                Status = updatedMoto.Status.ToString(),
                UltimaAtualizacao = updatedMoto.UltimaAtualizacao,
                PatioId = updatedMoto.PatioId,
                LocalizacaoId = updatedMoto.LocalizacaoId,
                FuncionarioId = updatedMoto.FuncionarioId
            };
        }

        public async Task DeleteAsync(long id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
                throw new DomainException("Moto não encontrada.");

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
        }
    }
}
