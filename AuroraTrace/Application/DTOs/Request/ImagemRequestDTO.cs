namespace AuroraTrace.Application.DTOs.Request
{
    public class ImagemRequestDto
    {
        public string CaminhoArquivo { get; set; }
        public long CameraId { get; set; }
        public long? MotoId { get; set; }
    }
}
