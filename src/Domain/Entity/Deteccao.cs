namespace Domain.Entity;

using Domain.Exceptions;
using System;

public class Deteccao
{
    public long Id { get; private set; }
    public string? Placa { get; private set; }
    public string? ModeloProb { get; private set; }
    public double Confianca { get; private set; }

    public int BboxX { get; private set; }
    public int BboxY { get; private set; }
    public int BboxW { get; private set; }
    public int BboxH { get; private set; }

    public string? SetorEstimado { get; private set; }
    public string? SlotEstimado { get; private set; }

    public DateTime Timestamp { get; private set; }

    private Deteccao(string? placa, string? modeloProb, double confianca,
                     int x, int y, int w, int h, string? setor, string? slot)
    {
        if (confianca < 0 || confianca > 1)
            throw new DomainException("Confiança deve estar entre 0 e 1");

        Placa = placa?.ToUpper();
        ModeloProb = modeloProb;
        Confianca = confianca;
        BboxX = x;
        BboxY = y;
        BboxW = w;
        BboxH = h;
        SetorEstimado = setor;
        SlotEstimado = slot;
        Timestamp = DateTime.UtcNow;
    }

    internal static Deteccao Create(string? placa, string? modeloProb, double confianca,
                                    int x, int y, int w, int h, string? setor, string? slot)
    {
        return new Deteccao(placa, modeloProb, confianca, x, y, w, h, setor, slot);
    }

    public Deteccao() { }
}
