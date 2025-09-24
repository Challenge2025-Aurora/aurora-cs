namespace Application.DTOs.Response
{
    public class PatioResponseDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Cols { get; set; }
        public int Rows { get; set; }

        public List<SetorResponseDto> Setores { get; set; } = new();
    }
}
