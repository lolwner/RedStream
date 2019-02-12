using RedStream.DataAccessLayer.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace RedStream.DataAccessLayer.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected ApplicationDbContext DbContext { get; private set; }
        protected abstract DbSet<TEntity> DbSet { get; }
        public virtual IQueryable<TEntity> All => DbSet.AsNoTracking();

        public async Task<TEntity> CreateAsync(TEntity item)
        {
            var entity = DbSet.Add(item).Entity;
            //await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await All.ToListAsync();
            }

            return All.Where(predicate.Compile()).ToList();
        }
    }
}
