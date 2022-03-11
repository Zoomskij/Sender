using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SenderApp.Models;
using SenderApp.Repositories.Interfaces;
using SenderApp.Services.Interfaces;

namespace SenderApp.Services
{
    public class CommonService<T> : ICommonService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        public CommonService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FirstAsync(predicate);
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FirstOrDefaultAsync(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindBy(predicate).ToList();
        }

        public async Task<T> FindAsync(params object[] keys)
        {
            return await _repository.FindAsync(keys);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(params object[] keys)
        {
            var entity = await _repository.FindAsync(keys);
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
