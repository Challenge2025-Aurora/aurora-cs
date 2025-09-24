using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using AutoMapper;
using Infrastructure.Context;

namespace Application.Services
{
    public class DeteccaoService : BaseService<Deteccao, DeteccaoRequestDto, DeteccaoResponseDto>
    {
        public DeteccaoService(AuroraTraceContext context, IMapper mapper)
            : base(context, mapper) { }
    }
}
