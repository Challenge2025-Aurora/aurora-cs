using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entity;

namespace Domain.Repositories
{
    public interface IDeteccaoRepository
    {
        Task<List<Deteccao>> GetAllAsync();
        Task<Deteccao?> GetByIdAsync(string id);
        Task CreateAsync(Deteccao deteccao);
        Task UpdateAsync(string id, Deteccao deteccao);
        Task DeleteAsync(string id);
    }
}
