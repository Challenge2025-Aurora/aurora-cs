using Application.Services;
using Domain.Entity;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CameraController : BaseController<Camera, CameraRequestDto, CameraResponseDto>
    {
        public CameraController(CameraService service) : base(service) { }
    }
}
