using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIDAsync(int id);

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        IQueryable<T> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        Task RemoveRange(IEnumerable<T> entities);
    }
}
