using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Motos", "Gerencia o cadastro e o status de localização das motocicletas.")]
    public class MotoController : BaseController<Moto, MotoRequestDto, MotoResponseDto>
    {
        public MotoController(MotoService service) : base(service) { }
    }
}