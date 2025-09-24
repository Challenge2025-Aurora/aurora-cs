using Application.DTOs;
using System;
using System.Collections.Generic;

namespace Application.DTOs.Response
{
    public class EventoResponseDto
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public string? Descricao { get; set; }
        public DateTime CriadoEm { get; set; }

        public long MotoId { get; set; }

        public List<LinkDto> Links { get; set; } = new();
    }
}
