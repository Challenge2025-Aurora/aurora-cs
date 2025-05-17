using AuroraTrace.Domain.Entity;
using AuroraTrace.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuroraTrace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacaoController : ControllerBase
    {
        private readonly AuroraTraceContext _context;

        public LocalizacaoController(AuroraTraceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localizacao>>> GetAll()
        {
            var localizacoes = await _context.Localizacoes.ToListAsync();
            return Ok(localizacoes);
        }
    }
}
