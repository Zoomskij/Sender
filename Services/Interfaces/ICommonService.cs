using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PrintLayer.Models;

namespace PrintLayer.Services.Interfaces
{
    public interface ICommonService<T> where T : BaseEntity
    {
        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(params object[] keys);

        Task AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteAsync(params object[] keys);

        Task UpdateAsync(T entity);
    }
}
