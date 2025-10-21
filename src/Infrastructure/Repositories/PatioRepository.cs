using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class PatioRepository : IPatioRepository
    {
        private readonly IMongoCollection<Patio> _collection;

        public PatioRepository(AuroraMongoContext context)
        {
            _collection = context.Patios;
        }

        public async Task<List<Patio>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();

        public Task<Patio?> GetByIdAsync(string id)
            => _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public Task CreateAsync(Patio x)
            => _collection.InsertOneAsync(x);

        public Task UpdateAsync(string id, Patio x)
        {
            x.Id = id;
            return _collection.ReplaceOneAsync(d => d.Id == id, x);
        }

        public Task DeleteAsync(string id)
            => _collection.DeleteOneAsync(d => d.Id == id);
    }
}
