using Domain.Entity;

namespace Domain.Repositories
{
    public interface IMotoRepository
    {
        Task<List<Moto>> GetAllAsync();
        Task<Moto?> GetByIdAsync(string id);
        Task CreateAsync(Moto moto);
        Task UpdateAsync(string id, Moto moto);
        Task DeleteAsync(string id);
    }
}
