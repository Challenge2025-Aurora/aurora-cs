using Application.Services;
using Domain.Entity;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class SetorController : BaseController<Setor, SetorRequestDto, SetorResponseDto>
    {
        public SetorController(SetorService service) : base(service) { }
    }
}
