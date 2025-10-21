using Application.DTOs;
using Domain.Enum;
using System;
using System.Collections.Generic;

namespace Application.DTOs.Response
{
    public class MotoResponseDto
    {
        public string Id { get; set; } = default!;
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public StatusMoto Status { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public string? UltimoSetor { get; set; }
        public string? UltimoSlot { get; set; }

        public List<LinkDto> Links { get; set; } = new();
    }
}
