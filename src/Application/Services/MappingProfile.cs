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
            CreateMap<Funcionario, FuncionarioResponseDto>();
            CreateMap<FuncionarioRequestDto, Funcionario>();

            CreateMap<Moto, MotoResponseDTO>();
            CreateMap<MotoRequestDTO, Moto>();

            CreateMap<Camera, CameraResponseDto>();
            CreateMap<CameraRequestDto, Camera>();

            CreateMap<Patio, PatioResponseDto>();
            CreateMap<PatioRequestDto, Patio>();

            CreateMap<Localizacao, LocalizacaoResponseDto>();
            CreateMap<LocalizacaoRequestDto, Localizacao>();

            CreateMap<Imagem, ImagemResponseDto>();
            CreateMap<ImagemRequestDto, Imagem>();
        }
    }
}
