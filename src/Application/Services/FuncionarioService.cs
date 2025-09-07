using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using AutoMapper;
using Infrastructure.Context;

namespace Application.Services
{
    public class FuncionarioService : BaseService<Funcionario, FuncionarioRequestDto, FuncionarioResponseDto>
    {
        public FuncionarioService(AuroraTraceContext context, IMapper mapper)
            : base(context, mapper) { }
    }
}
