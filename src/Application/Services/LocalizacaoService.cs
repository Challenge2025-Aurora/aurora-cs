using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using AutoMapper;
using Infrastructure.Context;

namespace Application.Services
{
    public class LocalizacaoService : BaseService<Localizacao, LocalizacaoRequestDto, LocalizacaoResponseDto>
    {
        public LocalizacaoService(AuroraTraceContext context, IMapper mapper)
            : base(context, mapper) { }
    }
}
