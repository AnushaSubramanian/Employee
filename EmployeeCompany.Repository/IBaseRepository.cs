using EmployeeCompany.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeCompany.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
         
        ValueTask<TEntity> GetById(Guid UUID);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
		void UpdateRange(IEnumerable<TEntity> entities);
		Task UpdateAsync(TEntity entity);       
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
