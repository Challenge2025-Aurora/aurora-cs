namespace AuroraTrace.Application.DTO
{
    public class MotoRequestDTO
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Status { get; set; }
        public long PatioId { get; set; }
        public long LocalizacaoId { get; set; }
        public long? FuncionarioId { get; set; }
    }
}
