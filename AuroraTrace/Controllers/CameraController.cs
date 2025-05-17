using AuroraTrace.Domain.Entity;
using AuroraTrace.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuroraTrace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CameraController : ControllerBase
    {
        private readonly AuroraTraceContext _context;

        public CameraController(AuroraTraceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camera>>> GetAll()
        {
            var cameras = await _context.Cameras.ToListAsync();
            return Ok(cameras);
        }
    }
}
