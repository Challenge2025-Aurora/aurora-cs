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

        public async Task<Setor?> GetByIdAsync(string id)
            => await _collection.Find(s => s.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Setor setor)
            => await _collection.InsertOneAsync(setor);

        public async Task UpdateAsync(string id, Setor setor)
            => await _collection.ReplaceOneAsync(s => s.Id.ToString() == id, setor);

        public async Task DeleteAsync(string id)
            => await _collection.DeleteOneAsync(s => s.Id.ToString() == id);
    }
}
