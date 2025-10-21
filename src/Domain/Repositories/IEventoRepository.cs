using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Repositories
{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(string id);
        Task CreateAsync(Evento evento);
        Task UpdateAsync(string id, Evento evento);
        Task DeleteAsync(string id);
    }
}
