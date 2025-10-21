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
    public class SetorRepository : ISetorRepository
    {
        private readonly IMongoCollection<Setor> _collection;

        public SetorRepository(AuroraMongoContext context)
        {
            _collection = context.Setores;
        }

        public async Task<List<Setor>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();
        public Task<Setor?> GetByIdAsync(string id)
            => _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public Task CreateAsync(Setor x)
            => _collection.InsertOneAsync(x);

        public Task UpdateAsync(string id, Setor x)
        {
            x.Id = id;
            return _collection.ReplaceOneAsync(d => d.Id == id, x);
        }

        public Task DeleteAsync(string id)
            => _collection.DeleteOneAsync(d => d.Id == id);
    }
}
