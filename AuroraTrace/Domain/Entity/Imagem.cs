using AuroraTrace.Domain.Exceptions;

namespace AuroraTrace.Domain.Entity
{
    public class Imagem
    {
        public Guid Id { get; private set; }
        public string CaminhoArquivo { get; private set; }
        public DateTime CapturadaEm { get; private set; }

        public Guid CameraId { get; private set; }
        public virtual Camera Camera { get; private set; }

        public Guid? MotoId { get; private set; }
        public virtual Moto? Moto { get; private set; }

        private Imagem(string caminhoArquivo, Guid cameraId, Guid? motoId)
        {
            if (string.IsNullOrWhiteSpace(caminhoArquivo))
                throw new DomainException("Caminho da imagem é obrigatório");

            Id = Guid.NewGuid();
            CaminhoArquivo = caminhoArquivo;
            CameraId = cameraId;
            MotoId = motoId;
            CapturadaEm = DateTime.UtcNow;
        }

        internal static Imagem Create(string caminhoArquivo, Guid cameraId, Guid? motoId)
        {
            return new Imagem(caminhoArquivo, cameraId, motoId);
        }

        public Imagem() { }
    }
}
