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

        public async Task<Evento?> GetByIdAsync(string id)
            => await _collection.Find(e => e.Id.ToString() == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Evento evento)
            => await _collection.InsertOneAsync(evento);

        public async Task UpdateAsync(string id, Evento evento)
            => await _collection.ReplaceOneAsync(e => e.Id.ToString() == id, evento);

        public async Task DeleteAsync(string id)
            => await _collection.DeleteOneAsync(e => e.Id.ToString() == id);
    }
}
