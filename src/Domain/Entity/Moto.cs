namespace Domain.Entity;

using Domain.Exceptions;
using Domain.Enum;
using Domain.ValueObject;
using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Moto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public Placa Placa { get; private set; } = null!;
    public string Modelo { get; private set; } = null!;
    public StatusMoto Status { get; private set; }
    public DateTime AtualizadoEm { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public string? UltimoSetor { get; private set; }
    public string? UltimoSlot { get; private set; }

    private Moto(Placa placa, string modelo, StatusMoto status, string? setor, string? slot)
    {
        if (placa is null || string.IsNullOrWhiteSpace(placa.Valor))
            throw new DomainException("Placa é obrigatória");
        if (string.IsNullOrWhiteSpace(modelo))
            throw new DomainException("Modelo é obrigatório");

        Placa = placa;
        Modelo = modelo;
        Status = status;
        AtualizadoEm = DateTime.UtcNow;
        DataCadastro = DateTime.UtcNow;
        UltimoSetor = setor;
        UltimoSlot = slot;
    }

    public static Moto Create(Placa placa, string modelo, StatusMoto status, string? setor, string? slot)
        => new Moto(placa, modelo, status, setor, slot);

    public void AtualizarStatus(StatusMoto novoStatus, string? setor = null, string? slot = null)
    {
        Status = novoStatus;
        UltimoSetor = setor;
        UltimoSlot = slot;
        AtualizadoEm = DateTime.UtcNow;
    }

    public Moto() { }
}
