namespace Domain.Entity;

using Domain.Exceptions;
using Domain.Entity;
using Domain.Enum;
using System.Text.RegularExpressions;

public class Moto
{
    public long Id { get; private set; }
    public string Placa { get; private set; }
    public string Modelo { get; private set; }
    public StatusMoto Status { get; private set; }
    public DateTime UltimaAtualizacao { get; private set; }

    public long PatioId { get; private set; }
    public virtual Patio Patio { get; private set; }

    public long? FuncionarioId { get; private set; }
    public virtual Funcionario? Funcionario { get; private set; }

    public Localizacao Localizacao { get; private set; }

    private Moto(string placa, string modelo, StatusMoto status, long patioId, Localizacao localizacao, long? funcionarioId)
    {
        ValidarPlaca(placa);

        Placa = placa;
        Modelo = modelo ?? throw new DomainException("Modelo é obrigatório");
        Status = status;
        UltimaAtualizacao = DateTime.UtcNow;
        PatioId = patioId;
        Localizacao = localizacao ?? throw new DomainException("Localização é obrigatória");
        FuncionarioId = funcionarioId;
    }

    private void ValidarPlaca(string placa)
    {
        if (string.IsNullOrWhiteSpace(placa))
            throw new DomainException("Placa é obrigatória");

        var regex = new Regex(@"^[A-Z]{3}\d{4}$|^[A-Z]{3}[0-9][A-Z][0-9]{2}$", RegexOptions.IgnoreCase);
        if (!regex.IsMatch(placa))
            throw new DomainException($"Placa inválida: {placa}");
    }

    internal static Moto Create(string placa, string modelo, StatusMoto status, long patioId, Localizacao localizacao, long? funcionarioId)
    {
        return new Moto(placa, modelo, status, patioId, localizacao, funcionarioId);
    }

    public Moto() { }
}