namespace AuroraTrace.Application.DTOs.Request
{
    public class MotoRequestDto
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int Status { get; set; }
        public Guid PatioId { get; set; }
        public Guid LocalizacaoId { get; set; }
        public Guid? FuncionarioId { get; set; }
    }

}
