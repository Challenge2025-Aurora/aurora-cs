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
    [SwaggerTag("Detecções", "Gerencia os dados brutos de detecção de motos via Visão Computacional.")]
    public class DeteccaoController : BaseController<Deteccao, DeteccaoRequestDto, DeteccaoResponseDto>
    {
        public DeteccaoController(DeteccaoService service) : base(service) { }
    }
}