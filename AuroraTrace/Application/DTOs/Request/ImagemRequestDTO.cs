namespace AuroraTrace.Application.DTOs.Request
{
    public class ImagemRequestDto
    {
        public string CaminhoArquivo { get; set; }
        public Guid CameraId { get; set; }
        public Guid? MotoId { get; set; }
    }

}
