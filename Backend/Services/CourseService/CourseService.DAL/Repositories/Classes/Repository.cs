using Microsoft.EntityFrameworkCore;
using CourseService.DAL.Repositories.Interfaces;
using CourseService.DAL.Entities;
using CourseService.DAL.DatabaseContext;

namespace CourseService.DAL.Repositories.Classes;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly CourseServiceDbContext _context;
    private readonly DbSet<T> _dbSet;
    
    public Repository(CourseServiceDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}