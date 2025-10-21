using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;
using Domain.ValueObject;

namespace Application.Services
{
    public class MotoService
    {
        private readonly IMotoRepository _repo;
        private readonly IMapper _mapper;

        public MotoService(IMotoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<MotoResponseDto>> GetAllAsync()
        {
            var motos = await _repo.GetAllAsync();
            return _mapper.Map<List<MotoResponseDto>>(motos);
        }

        public async Task<MotoResponseDto?> GetByIdAsync(string id)
        {
            var moto = await _repo.GetByIdAsync(id);
            return moto is null ? null : _mapper.Map<MotoResponseDto>(moto);
        }

        public async Task<MotoResponseDto> CreateAsync(MotoRequestDto dto)
        {
            var moto = Moto.Create(
                new Placa(dto.Placa),
                dto.Modelo,
                dto.Status,
                dto.UltimoSetor,
                dto.UltimoSlot
            );

            await _repo.CreateAsync(moto);
            return _mapper.Map<MotoResponseDto>(moto);
        }

        public async Task<MotoResponseDto?> UpdateAsync(string id, MotoRequestDto dto)
        {
            var moto = Moto.Create(
                new Placa(dto.Placa),
                dto.Modelo,
                dto.Status,
                dto.UltimoSetor,
                dto.UltimoSlot
            );

            await _repo.UpdateAsync(id, moto);
            return _mapper.Map<MotoResponseDto>(moto);
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
