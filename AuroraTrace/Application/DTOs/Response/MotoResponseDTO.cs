namespace AuroraTrace.Application.DTOs.Response
{
    public class MotoResponseDto
    {
        public long Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Status { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
