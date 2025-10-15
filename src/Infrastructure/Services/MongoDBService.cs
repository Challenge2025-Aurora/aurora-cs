using Domain.Entity;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;
        
        public MongoDBService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            _database = client.GetDatabase("ChallengeDb");
        }

        public IMongoCollection<Moto> Motos => _database.GetCollection<Moto>("Motos");
    }
}

