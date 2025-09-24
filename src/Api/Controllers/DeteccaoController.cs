using Application.Services;
using Domain.Entity;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class DeteccaoController : BaseController<Deteccao, DeteccaoRequestDto, DeteccaoResponseDto>
    {
        public DeteccaoController(DeteccaoService service) : base(service) { }
    }
}
