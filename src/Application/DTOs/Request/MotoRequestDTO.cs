namespace Application.DTOs.Request
{
    public class MotoRequestDTO
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Status { get; set; }
        public long PatioId { get; set; }
        public Localizacao Localizacao { get; set; }
        public long? FuncionarioId { get; set; }
    }
}
