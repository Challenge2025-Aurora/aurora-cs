using MongoDB.Driver;
using Domain.Entity;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class AuroraMongoContext
    {
        private readonly IMongoDatabase _database;

        public AuroraMongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("AuroraTraceDb");
        }

        public IMongoCollection<Moto> Motos => _database.GetCollection<Moto>("Motos");
        public IMongoCollection<Patio> Patios => _database.GetCollection<Patio>("Patios");
        public IMongoCollection<Setor> Setores => _database.GetCollection<Setor>("Setores");
        public IMongoCollection<Evento> Eventos => _database.GetCollection<Evento>("Eventos");
        public IMongoCollection<Deteccao> Deteccoes => _database.GetCollection<Deteccao>("Deteccoes");
    }
}
