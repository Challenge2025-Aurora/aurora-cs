namespace Domain.Entity;

using Domain.Exceptions;
using Domain.Enum;

public class Moto
{
    public long Id { get; private set; }
    public string Placa { get; private set; }
    public string Modelo { get; private set; }
    public StatusMoto Status { get; private set; }
    public DateTime AtualizadoEm { get; private set; }

    public string? UltimoSetor { get; private set; }
    public string? UltimoSlot { get; private set; }

    private Moto(string placa, string modelo, StatusMoto status, string? setor, string? slot)
    {
        if (string.IsNullOrWhiteSpace(placa))
            throw new DomainException("Placa é obrigatória");
        if (string.IsNullOrWhiteSpace(modelo))
            throw new DomainException("Modelo é obrigatório");

        Placa = placa.ToUpper();
        Modelo = modelo;
        Status = status;
        AtualizadoEm = DateTime.UtcNow;
        UltimoSetor = setor;
        UltimoSlot = slot;
    }

    internal static Moto Create(string placa, string modelo, StatusMoto status, string? setor, string? slot)
    {
        return new Moto(placa, modelo, status, setor, slot);
    }

    public void AtualizarStatus(StatusMoto novoStatus, string? setor = null, string? slot = null)
    {
        Status = novoStatus;
        UltimoSetor = setor;
        UltimoSlot = slot;
        AtualizadoEm = DateTime.UtcNow;
    }

    public Moto() { }
}
