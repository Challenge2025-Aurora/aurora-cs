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
    [SwaggerTag("Setores", "Gerencia as áreas de agrupamento de vagas (Slots) dentro de cada pátio.")]
    public class SetorController : BaseController<Setor, SetorRequestDto, SetorResponseDto>
    {
        public SetorController(SetorService service) : base(service) { }
    }
}