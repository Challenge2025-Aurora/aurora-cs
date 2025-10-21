namespace Application.DTOs.Response
{
    public class PatioResponseDto
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; }
        public int Cols { get; set; }
        public int Rows { get; set; }

        public List<SetorResponseDto> Setores { get; set; } = new();
    }
}
