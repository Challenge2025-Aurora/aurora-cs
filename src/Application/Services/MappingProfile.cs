using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using AutoMapper;

namespace Application.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Moto, MotoResponseDto>();
            CreateMap<MotoRequestDto, Moto>();

            CreateMap<Patio, PatioResponseDto>();
            CreateMap<PatioRequestDto, Patio>();

            CreateMap<Setor, SetorResponseDto>();
            CreateMap<SetorRequestDto, Setor>();

            CreateMap<Evento, EventoResponseDto>();
            CreateMap<EventoRequestDto, Evento>();

            CreateMap<Deteccao, DeteccaoResponseDto>();
            CreateMap<DeteccaoRequestDto, Deteccao>();
        }
    }
}
