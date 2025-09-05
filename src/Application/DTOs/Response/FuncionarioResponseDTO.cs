namespace Application.DTOs.Response
{
    public class FuncionarioResponseDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cargo { get; set; }
        public string? Telefone { get; set; }
    }
}
