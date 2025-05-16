using AuroraTrace.Domain.Exceptions;

public class Camera
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public string Posicao { get; private set; }

    public long PatioId { get; private set; }
    public virtual Patio Patio { get; private set; }

    public DateTime InstaladaEm { get; private set; }

    private Camera(string nome, string posicao, long patioId)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome da câmera é obrigatório");
        if (string.IsNullOrWhiteSpace(posicao))
            throw new DomainException("Posição da câmera é obrigatória");

        Nome = nome;
        Posicao = posicao;
        PatioId = patioId;
        InstaladaEm = DateTime.UtcNow;
    }

    internal static Camera Create(string nome, string posicao, long patioId)
    {
        return new Camera(nome, posicao, patioId);
    }

    public Camera() { }
}
