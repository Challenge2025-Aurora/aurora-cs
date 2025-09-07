using Application.Services;
using Domain.Entity;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class LocalizacaoController : BaseController<Localizacao, LocalizacaoRequestDto, LocalizacaoResponseDto>
    {
        public LocalizacaoController(LocalizacaoService service) : base(service) { }
    }
}
