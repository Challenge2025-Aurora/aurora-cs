using AuroraTrace.Domain.Exceptions;

namespace AuroraTrace.Domain.Entity
{
    public class Camera
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Posicao { get; private set; }

        public Guid PatioId { get; private set; }
        public virtual Patio Patio { get; private set; }

        public DateTime InstaladaEm { get; private set; }

        private Camera(string nome, string posicao, Guid patioId)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("Nome da câmera é obrigatório");
            if (string.IsNullOrWhiteSpace(posicao))
                throw new DomainException("Posição da câmera é obrigatória");

            Id = Guid.NewGuid();
            Nome = nome;
            Posicao = posicao;
            PatioId = patioId;
            InstaladaEm = DateTime.UtcNow;
        }

        internal static Camera Create(string nome, string posicao, Guid patioId)
        {
            return new Camera(nome, posicao, patioId);
        }

        public Camera() { }
    }
}
