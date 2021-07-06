using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using EmployeeCompany.Repository;
using EmployeeCompany.Model;
using EmployeeCompany.DB;

namespace DynamicContent.Repository.Repositories
{

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _context;

        private readonly DbSet<TEntity> _entities;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            _context.SaveChanges();


        }
        public async Task UpdateAsync(TEntity entity)
        {
            var oldEntity = await _context.FindAsync<TEntity>(entity.UUID);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();

        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
            _context.SaveChanges();


        }
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            _context.SaveChanges();


        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public ValueTask<TEntity> GetById(Guid UUID)
        {
            return _entities.FindAsync(UUID);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {

            _entities.RemoveRange(entities);
            _context.SaveChanges();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefaultAsync(predicate);
        }


    }

}
