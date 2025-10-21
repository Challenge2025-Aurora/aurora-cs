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

        public async Task<Deteccao?> GetByIdAsync(string id)
            => await _collection.Find(d => d.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Deteccao deteccao)
            => await _collection.InsertOneAsync(deteccao);

        public async Task UpdateAsync(string id, Deteccao deteccao)
            => await _collection.ReplaceOneAsync(d => d.Id.ToString() == id, deteccao);

        public async Task DeleteAsync(string id)
            => await _collection.DeleteOneAsync(d => d.Id.ToString() == id);
    }
}
