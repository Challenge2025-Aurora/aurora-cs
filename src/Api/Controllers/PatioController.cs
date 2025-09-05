using Domain.Entity;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatioController : ControllerBase
    {
        private readonly AuroraTraceContext _context;

        public PatioController(AuroraTraceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patio>>> GetAll()
        {
            var patios = await _context.Patios.ToListAsync();
            return Ok(patios);
        }
    }
}
