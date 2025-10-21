using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Repositories
{
    public interface IPatioRepository
    {
        Task<List<Patio>> GetAllAsync();
        Task<Patio?> GetByIdAsync(string id);
        Task CreateAsync(Patio patio);
        Task UpdateAsync(string id, Patio patio);
        Task DeleteAsync(string id);
    }
}
