namespace Domain.Entity;

using Domain.Exceptions;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Patio
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Nome { get; private set; } = null!;
    public int Cols { get; private set; }
    public int Rows { get; private set; }

    private readonly List<Setor> _setores = new();
    public virtual IReadOnlyCollection<Setor> Setores => _setores.AsReadOnly();

    private Patio(string nome, int cols, int rows)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome do pátio é obrigatório");
        if (cols <= 0 || rows <= 0)
            throw new DomainException("Mapa do pátio deve ter dimensões válidas");

        Nome = nome;
        Cols = cols;
        Rows = rows;
    }

    internal static Patio Create(string nome, int cols, int rows)
    {
        return new Patio(nome, cols, rows);
    }

    public Patio() { }
}