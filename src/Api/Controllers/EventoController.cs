using Application.Services;
using Domain.Entity;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class EventoController : BaseController<Evento, EventoRequestDto, EventoResponseDto>
    {
        public EventoController(EventoService service) : base(service) { }
    }
}
