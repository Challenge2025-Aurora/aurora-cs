namespace Application.DTOs.Request
{
    public class EventoRequestDto
    {
        public string Tipo { get; set; }
        public string? Descricao { get; set; }
        public long MotoId { get; set; }
    }
}
