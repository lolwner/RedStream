using RedStream.DataAccessLayer.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RedStream.DataAccessLayer.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected abstract DbSet<TEntity> DbSet { get; }

        public async Task<TEntity> CreateAsync(TEntity item)
        {
            var entity = DbSet.Add(item).Entity;
            //await DbContext.SaveChangesAsync();
            return entity;
        }
    }
}
