namespace AuroraTrace.Application.DTOs.Request
{
    public class MotoRequestDto
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int Status { get; set; }
        public long PatioId { get; set; }
        public long LocalizacaoId { get; set; }
        public long? FuncionarioId { get; set; }
    }
}
