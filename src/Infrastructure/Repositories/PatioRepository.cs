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

        public async Task<Patio?> GetByIdAsync(string id)
            => await _collection.Find(p => p.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Patio patio)
            => await _collection.InsertOneAsync(patio);

        public async Task UpdateAsync(string id, Patio patio)
            => await _collection.ReplaceOneAsync(p => p.Id.ToString() == id, patio);

        public async Task DeleteAsync(string id)
            => await _collection.DeleteOneAsync(p => p.Id.ToString() == id);
    }
}
