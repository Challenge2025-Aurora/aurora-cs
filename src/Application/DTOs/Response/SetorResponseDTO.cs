namespace Application.DTOs.Response
{
    public class SetorResponseDto
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; }
        public int Slots { get; set; }
        public long PatioId { get; set; }
    }
}
