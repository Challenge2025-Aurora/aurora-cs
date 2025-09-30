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
    [SwaggerTag("Detec��es", "Gerencia os dados brutos de detec��o de motos via Vis�o Computacional.")]
    public class DeteccaoController : BaseController<Deteccao, DeteccaoRequestDto, DeteccaoResponseDto>
    {
        public DeteccaoController(DeteccaoService service) : base(service) { }
    }
}