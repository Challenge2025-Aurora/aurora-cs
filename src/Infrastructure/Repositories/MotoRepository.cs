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

        public Task<List<Moto>> GetAllAsync()
            => _collection.Find(FilterDefinition<Moto>.Empty).ToListAsync();

        public Task<Moto?> GetByIdAsync(string id)
            => _collection.Find(m => m.Id == id).FirstOrDefaultAsync();

        public Task CreateAsync(Moto moto)
            => _collection.InsertOneAsync(moto);

        public Task UpdateAsync(string id, Moto moto)
        {
            moto.GetType().GetProperty("Id")?.SetValue(moto, id);
            return _collection.ReplaceOneAsync(m => m.Id == id, moto);
        }

        public Task DeleteAsync(string id)
            => _collection.DeleteOneAsync(m => m.Id == id);
    }
}
