using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;

namespace Application.Services
{
    public class PatioService
    {
        private readonly IPatioRepository _repo;
        private readonly IMapper _mapper;

        public PatioService(IPatioRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PatioResponseDto>> GetAllAsync()
        {
            var patios = await _repo.GetAllAsync();
            return _mapper.Map<List<PatioResponseDto>>(patios);
        }

        public async Task<PatioResponseDto?> GetByIdAsync(string id)
        {
            var patio = await _repo.GetByIdAsync(id);
            return patio is null ? null : _mapper.Map<PatioResponseDto>(patio);
        }

        public async Task<PatioResponseDto> CreateAsync(PatioRequestDto dto)
        {
            var patio = _mapper.Map<Patio>(dto);
            await _repo.CreateAsync(patio);
            return _mapper.Map<PatioResponseDto>(patio);
        }

        public async Task<PatioResponseDto?> UpdateAsync(string id, PatioRequestDto dto)
        {
            var patio = _mapper.Map<Patio>(dto);
            await _repo.UpdateAsync(id, patio);
            return _mapper.Map<PatioResponseDto>(patio);
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
