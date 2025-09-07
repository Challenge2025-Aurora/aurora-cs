using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using AutoMapper;
using Infrastructure.Context;

namespace Application.Services
{
    public class ImagemService : BaseService<Imagem, ImagemRequestDto, ImagemResponseDto>
    {
        public ImagemService(AuroraTraceContext context, IMapper mapper)
            : base(context, mapper) { }
    }
}
