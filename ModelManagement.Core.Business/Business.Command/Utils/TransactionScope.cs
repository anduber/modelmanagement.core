using ModelManagement.Core.Data.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Command.Utils
{
    public class TransactionScope : IDisposable
    {
        public ModelManagementContext Context;
        private readonly DbContextTransaction _dbTransaction;

        public TransactionScope()
        {
            Context = new ModelManagementContext();
            _dbTransaction = Context.Database.BeginTransaction();
        }

        public void CompleteTransaction()
        {
            try
            {
                Context.SaveChanges();
                _dbTransaction.Commit();
            }
            catch (Exception)
            {
                RollBackTransaction();
                throw;
            }

        }

        public void RollBackTransaction()
        {
            _dbTransaction.Rollback();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
