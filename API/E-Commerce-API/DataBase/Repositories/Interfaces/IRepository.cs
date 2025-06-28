using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
        Task<T> GetByIdAsync(int id);
    IQueryable<T> GetAll();  
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}