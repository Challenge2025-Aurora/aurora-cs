using Application.Services;
using Domain.Entity;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Setores", "Gerencia as �reas de agrupamento de vagas (Slots) dentro de cada p�tio.")]
    public class SetorController : BaseController<Setor, SetorRequestDto, SetorResponseDto>
    {
        public SetorController(SetorService service) : base(service) { }
    }
}