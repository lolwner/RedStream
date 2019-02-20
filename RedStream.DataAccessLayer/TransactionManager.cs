using RedStream.DataAccessLayer.Interfaces;
using System;
using System.Threading.Tasks;

namespace RedStream.DataAccessLayer
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Begin()
        {
            this._dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            this._dbContext.Database.CommitTransaction();
        }

        public void RollBack()
        {
            this._dbContext.Database.RollbackTransaction();
        }

        public async Task ExecuteInTransaction(Func<Task> action)
        {
            Begin();

            try
            {
                await action();
                Commit();
            }
            catch(Exception exception)
            {
                RollBack();
                throw exception;
            }

        }
    }
}
