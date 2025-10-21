using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;

namespace Application.Services
{
    public class DeteccaoService
    {
        private readonly IDeteccaoRepository _repo;
        private readonly IMapper _mapper;

        public DeteccaoService(IDeteccaoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<DeteccaoResponseDto>> GetAllAsync()
        {
            var deteccoes = await _repo.GetAllAsync();
            return _mapper.Map<List<DeteccaoResponseDto>>(deteccoes);
        }

        public async Task<DeteccaoResponseDto?> GetByIdAsync(string id)
        {
            var deteccao = await _repo.GetByIdAsync(id);
            return deteccao is null ? null : _mapper.Map<DeteccaoResponseDto>(deteccao);
        }

        public async Task<DeteccaoResponseDto> CreateAsync(DeteccaoRequestDto dto)
        {
            var deteccao = _mapper.Map<Deteccao>(dto);
            await _repo.CreateAsync(deteccao);
            return _mapper.Map<DeteccaoResponseDto>(deteccao);
        }

        public async Task<DeteccaoResponseDto?> UpdateAsync(string id, DeteccaoRequestDto dto)
        {
            var deteccao = _mapper.Map<Deteccao>(dto);
            await _repo.UpdateAsync(id, deteccao);
            return _mapper.Map<DeteccaoResponseDto>(deteccao);
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
