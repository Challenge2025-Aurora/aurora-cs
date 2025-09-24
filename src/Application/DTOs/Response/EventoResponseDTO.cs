using System;

namespace Application.DTOs.Response
{
    public class EventoResponseDto
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public string? Descricao { get; set; }
        public DateTime CriadoEm { get; set; }

        public long MotoId { get; set; }
    }
}
