using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entity;
using Domain.Repositories;

namespace Application.Services
{
    public class EventoService
    {
        private readonly IEventoRepository _repo;
        private readonly IMapper _mapper;

        public EventoService(IEventoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<EventoResponseDto>> GetAllAsync()
        {
            var eventos = await _repo.GetAllAsync();
            return _mapper.Map<List<EventoResponseDto>>(eventos);
        }

        public async Task<EventoResponseDto?> GetByIdAsync(string id)
        {
            var evento = await _repo.GetByIdAsync(id);
            return evento is null ? null : _mapper.Map<EventoResponseDto>(evento);
        }

        public async Task<EventoResponseDto> CreateAsync(EventoRequestDto dto)
        {
            var evento = _mapper.Map<Evento>(dto);
            await _repo.CreateAsync(evento);
            return _mapper.Map<EventoResponseDto>(evento);
        }

        public async Task<EventoResponseDto?> UpdateAsync(string id, EventoRequestDto dto)
        {
            var evento = _mapper.Map<Evento>(dto);
            await _repo.UpdateAsync(id, evento);
            return _mapper.Map<EventoResponseDto>(evento);
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
