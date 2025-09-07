using Application.Services;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class BaseService<TEntity, TRequestDto, TResponseDto> : IService<TEntity, TRequestDto, TResponseDto>
    where TEntity : class
{
    private readonly AuroraTraceContext _context;
    private readonly IMapper _mapper;

    public BaseService(AuroraTraceContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TResponseDto>> GetAllAsync()
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        return _mapper.Map<IEnumerable<TResponseDto>>(entities);
    }

    public async Task<TResponseDto> GetByIdAsync(long id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null) throw new Exception("Entity not found");
        return _mapper.Map<TResponseDto>(entity);
    }

    public async Task<TResponseDto> CreateAsync(TRequestDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return _mapper.Map<TResponseDto>(entity);
    }

    public async Task<TResponseDto> UpdateAsync(long id, TRequestDto dto)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null) throw new Exception("Entity not found");

        _mapper.Map(dto, entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TResponseDto>(entity);
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null) throw new Exception("Entity not found");

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
