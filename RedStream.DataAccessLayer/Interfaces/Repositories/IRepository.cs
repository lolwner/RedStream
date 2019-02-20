using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedStream.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity item);
        Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
