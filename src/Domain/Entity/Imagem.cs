namespace Domain.Entity;

using Domain.Exceptions;

public class Imagem
    {
        public long Id { get; private set; }
        public string CaminhoArquivo { get; private set; }
        public DateTime CapturadaEm { get; private set; }

        public long CameraId { get; private set; }
        public virtual Camera Camera { get; private set; }

        public long? MotoId { get; private set; }
        public virtual Moto? Moto { get; private set; }

        private Imagem(string caminhoArquivo, long cameraId, long? motoId)
        {
            if (string.IsNullOrWhiteSpace(caminhoArquivo))
                throw new DomainException("Caminho da imagem é obrigatório");

            CaminhoArquivo = caminhoArquivo;
            CameraId = cameraId;
            MotoId = motoId;
            CapturadaEm = DateTime.UtcNow;
        }

        internal static Imagem Create(string caminhoArquivo, long cameraId, long? motoId)
        {
            return new Imagem(caminhoArquivo, cameraId, motoId);
        }

        public Imagem() { }
    }