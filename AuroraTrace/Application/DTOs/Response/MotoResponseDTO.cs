namespace AuroraTrace.Application.DTO
{
    public class MotoResponseDTO
    {
        public long Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Status { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public long PatioId { get; set; }
        public long LocalizacaoId { get; set; }
        public long? FuncionarioId { get; set; }
    }
}
