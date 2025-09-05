using Domain.Entity;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagemController : ControllerBase
    {
        private readonly AuroraTraceContext _context;

        public ImagemController(AuroraTraceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imagem>>> GetAll()
        {
            var imagens = await _context.Imagens.ToListAsync();
            return Ok(imagens);
        }
    }
}
