using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entity;

namespace Domain.Repositories
{
    public interface ISetorRepository
    {
        Task<List<Setor>> GetAllAsync();
        Task<Setor?> GetByIdAsync(string id);
        Task CreateAsync(Setor setor);
        Task UpdateAsync(string id, Setor setor);
        Task DeleteAsync(string id);
    }
}
