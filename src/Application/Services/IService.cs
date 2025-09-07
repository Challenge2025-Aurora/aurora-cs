using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IService<TEntity, TRequestDto, TResponseDto>
    {
        Task<IEnumerable<TResponseDto>> GetAllAsync();
        Task<TResponseDto> GetByIdAsync(long id);
        Task<TResponseDto> CreateAsync(TRequestDto dto);
        Task<TResponseDto> UpdateAsync(long id, TRequestDto dto);
        Task DeleteAsync(long id);
    }
}
