using Application.DTOs.Request;
using Application.DTOs.Response;
using Domain.Entity;
using AutoMapper;
using Infrastructure.Context;

namespace Application.Services
{
	public class EventoService : BaseService<Evento, EventoRequestDto, EventoResponseDto>
	{
		public EventoService(AuroraTraceContext context, IMapper mapper)
			: base(context, mapper) { }
	}
}
