using Core.DataAccess.Abstract;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public DbContext CurrentContext => _context;

        protected EfEntityRepositoryBase(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Queryable() => _context.Set<TEntity>().AsNoTracking();
        public DbSet<TEntity> Table() => _dbSet;
        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(ICollection<TEntity> entities)
        {
            if (entities.Count == 0) return;

            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(ICollection<TEntity> entities)
        {
            if (entities.Count == 0) return;

            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null) return;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(ICollection<TEntity> entities)
        {
            if (entities.Count == 0) return;

            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePartial(int id, object entity)
        {
            var item = await _context.Set<TEntity>().FindAsync(id);
            _context.Entry(item).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRange(ICollection<TEntity> entities)
        {
            if (entities.Count == 0) return;

            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<TEntity>> GetListAsync(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          int skip = 0, int take = int.MaxValue,
          params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null && includes.Length > 0)
                foreach (Expression<Func<TEntity, object>> include in includes)
                    query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            query = query.Skip(skip).Take(take);

            return await query.AsNoTracking().ToListAsync();

        }

        public async Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await GetListAsync(filter, null, 0, int.MaxValue);
        }

        public async Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return await GetListAsync(filter, null, includes: includes);
        }

        public async Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return await GetListAsync(filter, orderBy, 0, int.MaxValue, includes);
        }

        public async Task<ICollection<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id cannot be zero or less!");

            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }
        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
                return await _context.Set<TEntity>().CountAsync();

            return await _context.Set<TEntity>().CountAsync(expression);
        }
        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return await query.AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(where);
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.AsNoTracking().AnyAsync(where);
        }
    }
}
