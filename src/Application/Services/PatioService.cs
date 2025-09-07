using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using AutoMapper;
using Infrastructure.Context;

namespace Application.Services
{
    public class PatioService : BaseService<Patio, PatioRequestDto, PatioResponseDto>
    {
        public PatioService(AuroraTraceContext context, IMapper mapper)
            : base(context, mapper) { }
    }
}
