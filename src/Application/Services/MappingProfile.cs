using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using Domain.ValueObject;
using AutoMapper;

namespace Application.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Moto, MotoResponseDto>()
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Placa.Valor));

            CreateMap<MotoRequestDto, Moto>()
                .ConstructUsing(dto => Moto.Create(new Placa(dto.Placa), dto.Modelo, dto.Status, dto.UltimoSetor, dto.UltimoSlot));


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
