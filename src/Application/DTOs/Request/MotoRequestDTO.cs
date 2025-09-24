using Domain.Enum;

namespace Application.DTOs.Request
{
    public class MotoRequestDto
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public StatusMoto Status { get; set; }
        public string? UltimoSetor { get; set; }
        public string? UltimoSlot { get; set; }
    }
}
