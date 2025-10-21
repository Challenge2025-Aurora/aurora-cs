using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;

namespace Application.Services
{
    public class SetorService
    {
        private readonly ISetorRepository _repo;
        private readonly IMapper _mapper;

        public SetorService(ISetorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<SetorResponseDto>> GetAllAsync()
        {
            var setores = await _repo.GetAllAsync();
            return _mapper.Map<List<SetorResponseDto>>(setores);
        }

        public async Task<SetorResponseDto?> GetByIdAsync(string id)
        {
            var setor = await _repo.GetByIdAsync(id);
            return setor is null ? null : _mapper.Map<SetorResponseDto>(setor);
        }

        public async Task<SetorResponseDto> CreateAsync(SetorRequestDto dto)
        {
            var setor = _mapper.Map<Setor>(dto);
            await _repo.CreateAsync(setor);
            return _mapper.Map<SetorResponseDto>(setor);
        }

        public async Task<SetorResponseDto?> UpdateAsync(string id, SetorRequestDto dto)
        {
            var setor = _mapper.Map<Setor>(dto);
            await _repo.UpdateAsync(id, setor);
            return _mapper.Map<SetorResponseDto>(setor);
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
