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
    [SwaggerTag("Eventos", "Registra a linha do tempo de operações, status e movimentações das motos.")]
    public class EventoController : BaseController<Evento, EventoRequestDto, EventoResponseDto>
    {
        public EventoController(EventoService service) : base(service) { }
    }
}