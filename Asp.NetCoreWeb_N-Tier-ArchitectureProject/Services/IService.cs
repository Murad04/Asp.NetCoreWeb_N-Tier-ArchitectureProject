using System.Linq.Expressions;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIDAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}
