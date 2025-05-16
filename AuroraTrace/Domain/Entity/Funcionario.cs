using AuroraTrace.Domain.Exceptions;

public class Funcionario
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public string Matricula { get; private set; }
    public string Cargo { get; private set; }
    public string? Telefone { get; private set; }

    private Funcionario(string nome, string matricula, string cargo, string? telefone)
    {
        Nome = nome ?? throw new DomainException("Nome é obrigatório");
        Matricula = matricula ?? throw new DomainException("Matrícula é obrigatória");
        Cargo = cargo ?? throw new DomainException("Cargo é obrigatório");
        Telefone = telefone;
    }

    internal static Funcionario Create(string nome, string matricula, string cargo, string? telefone)
    {
        return new Funcionario(nome, matricula, cargo, telefone);
    }

    public Funcionario() { }
}
