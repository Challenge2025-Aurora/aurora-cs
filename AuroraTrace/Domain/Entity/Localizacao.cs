using AuroraTrace.Domain.Exceptions;

namespace AuroraTrace.Domain.Entity
{
    public class Localizacao
    {
        public Guid Id { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public DateTime RegistradaEm { get; private set; }

        private Localizacao(double latitude, double longitude)
        {
            Id = Guid.NewGuid();
            Latitude = latitude;
            Longitude = longitude;
            RegistradaEm = DateTime.UtcNow;
        }

        internal static Localizacao Create(double latitude, double longitude)
        {
            return new Localizacao(latitude, longitude);
        }

        public Localizacao() { }
    }
}
