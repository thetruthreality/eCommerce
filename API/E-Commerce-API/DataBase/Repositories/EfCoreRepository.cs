
using System.Linq.Expressions;
using ECommerceAPI.Database;
using Microsoft.EntityFrameworkCore;

public class EfCoreRepository<T> :IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public EfCoreRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public async Task InsertAsync(T entity)
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