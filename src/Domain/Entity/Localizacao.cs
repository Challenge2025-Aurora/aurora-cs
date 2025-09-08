using Domain.Exceptions;

public record Localizacao
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public Localizacao(double latitude, double longitude)
    {
        if (latitude < -90 || latitude > 90)
            throw new DomainException("Latitude inválida.");

        Latitude = latitude;
        Longitude = longitude;
    }
}