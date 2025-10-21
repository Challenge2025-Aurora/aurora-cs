using Domain.Entity;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Mongo
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;

        public MongoDBService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            _database = client.GetDatabase("AuroraDb");
        }

        public IMongoCollection<Moto> Motos => _database.GetCollection<Moto>("Motos");
        public IMongoCollection<Patio> Patios => _database.GetCollection<Patio>("Patios");
        public IMongoCollection<Setor> Setores => _database.GetCollection<Setor>("Setores");
        public IMongoCollection<Evento> Eventos => _database.GetCollection<Evento>("Eventos");
        public IMongoCollection<Deteccao> Deteccoes => _database.GetCollection<Deteccao>("Deteccoes");
    }
}
