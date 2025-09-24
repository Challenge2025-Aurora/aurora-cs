using Domain.Enum;

namespace Application.DTOs.Response
{
    public class MotoResponseDto
    {
        public long Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public StatusMoto Status { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public string? UltimoSetor { get; set; }
        public string? UltimoSlot { get; set; }
    }
}
