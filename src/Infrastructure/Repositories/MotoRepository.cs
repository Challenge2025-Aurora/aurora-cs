using Domain.Entity;
using Domain.Repositories;
using Infrastructure.Context;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly IMongoCollection<Moto> _collection;

        public MotoRepository(AuroraMongoContext context)
        {
            _collection = context.Motos;
        }

        public async Task<List<Moto>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();

        public async Task<Moto?> GetByIdAsync(string id)
            => await _collection.Find(m => m.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Moto moto)
            => await _collection.InsertOneAsync(moto);

        public async Task UpdateAsync(string id, Moto moto)
            => await _collection.ReplaceOneAsync(m => m.Id.ToString() == id, moto);

        public async Task DeleteAsync(string id)
            => await _collection.DeleteOneAsync(m => m.Id.ToString() == id);
    }
}
