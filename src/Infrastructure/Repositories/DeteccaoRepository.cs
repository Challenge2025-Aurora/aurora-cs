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
    public class DeteccaoRepository : IDeteccaoRepository
    {
        private readonly IMongoCollection<Deteccao> _collection;

        public DeteccaoRepository(AuroraMongoContext context)
        {
            _collection = context.Deteccoes;
        }

        public async Task<List<Deteccao>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();

        public Task<Deteccao?> GetByIdAsync(string id)
            => _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public Task CreateAsync(Deteccao x)
            => _collection.InsertOneAsync(x);

        public Task UpdateAsync(string id, Deteccao x)
        {
            x.Id = id;
            return _collection.ReplaceOneAsync(d => d.Id == id, x);
        }

        public Task DeleteAsync(string id)
            => _collection.DeleteOneAsync(d => d.Id == id);

    }  
}
