using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using AutoMapper;
using Infrastructure.Context;

namespace Application.Services
{
    public class CameraService : BaseService<Camera, CameraRequestDto, CameraResponseDto>
    {
        public CameraService(AuroraTraceContext context, IMapper mapper)
            : base(context, mapper) { }
    }
}
