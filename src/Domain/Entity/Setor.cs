namespace Domain.Entity;

using Domain.Exceptions;

public class Setor
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public int Slots { get; private set; }

    public long PatioId { get; private set; }
    public virtual Patio Patio { get; private set; }

    private Setor(string nome, int slots, long patioId)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome do setor é obrigatório");
        if (slots <= 0)
            throw new DomainException("Quantidade de slots deve ser positiva");

        Nome = nome;
        Slots = slots;
        PatioId = patioId;
    }

    internal static Setor Create(string nome, int slots, long patioId)
    {
        return new Setor(nome, slots, patioId);
    }

    public Setor() { }
}
