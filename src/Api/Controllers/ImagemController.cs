using Application.Services;
using Domain.Entity;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ImagemController : BaseController<Imagem, ImagemRequestDto, ImagemResponseDto>
    {
        public ImagemController(ImagemService service) : base(service) { }
    }
}
