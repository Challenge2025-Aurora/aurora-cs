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
    [SwaggerTag("Pátios", "Administra o layout e as dimensões dos pátios de filiais.")]
    public class PatioController : BaseController<Patio, PatioRequestDto, PatioResponseDto>
    {
        public PatioController(PatioService service) : base(service) { }
    }
}