using System.Linq.Expressions;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIDAsync(int id);

        IQueryable<T> GetAll();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
