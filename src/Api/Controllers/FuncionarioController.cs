using Application.Services;
using Domain.Entity;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class FuncionarioController : BaseController<Funcionario, FuncionarioRequestDto, FuncionarioResponseDto>
    {
        public FuncionarioController(FuncionarioService service) : base(service) { }
    }
}
