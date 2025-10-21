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
    public class EventoRepository : IEventoRepository
    {
        private readonly IMongoCollection<Evento> _collection;

        public EventoRepository(AuroraMongoContext context)
        {
            _collection = context.Eventos;
        }

        public async Task<List<Evento>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();

        public Task<Evento?> GetByIdAsync(string id)
            => _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public Task CreateAsync(Evento x)
            => _collection.InsertOneAsync(x);

        public Task UpdateAsync(string id, Evento x)
        {
            x.Id = id;
            return _collection.ReplaceOneAsync(d => d.Id == id, x);
        }

        public Task DeleteAsync(string id)
            => _collection.DeleteOneAsync(d => d.Id == id);

    }
}
