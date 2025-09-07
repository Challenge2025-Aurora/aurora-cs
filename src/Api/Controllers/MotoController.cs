using Application.Services;
using Domain.Entity;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class MotoController : BaseController<Moto, MotoRequestDTO, MotoResponseDTO>
    {
        public MotoController(MotoService service) : base(service) { }
    }
}
