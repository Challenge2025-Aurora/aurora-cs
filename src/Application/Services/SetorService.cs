using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using AutoMapper;
using Infrastructure.Context;

namespace Application.Services
{
    public class SetorService : BaseService<Setor, SetorRequestDto, SetorResponseDto>
    {
        public SetorService(AuroraTraceContext context, IMapper mapper)
            : base(context, mapper) { }
    }
}
