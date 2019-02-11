using System.Threading.Tasks;

namespace RedStream.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity item);
    }
}
