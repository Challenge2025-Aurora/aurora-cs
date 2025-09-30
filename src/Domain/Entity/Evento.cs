namespace Domain.Entity;

using Domain.Exceptions;
using System;

public class Evento
{
    public long Id { get; private set; }
    public string Tipo { get; private set; } = null!;
    public string? Descricao { get; private set; }
    public DateTime CriadoEm { get; private set; }

    public long MotoId { get; private set; }
    public virtual Moto Moto { get; private set; } = null!;

    private Evento(string tipo, string? descricao, long motoId)
    {
        if (string.IsNullOrWhiteSpace(tipo))
            throw new DomainException("Tipo do evento é obrigatório");

        Tipo = tipo;
        Descricao = descricao;
        MotoId = motoId;
        CriadoEm = DateTime.UtcNow;
    }

    internal static Evento Create(string tipo, string? descricao, long motoId)
    {
        return new Evento(tipo, descricao, motoId);
    }

    public Evento() { }
}