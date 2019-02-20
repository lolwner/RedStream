using System;
using System.Threading.Tasks;

namespace RedStream.DataAccessLayer.Interfaces
{
    public interface ITransactionManager
    {
        void Begin();

        void Commit();

        void RollBack();

        Task ExecuteInTransaction(Func<Task> action);
    }
}
