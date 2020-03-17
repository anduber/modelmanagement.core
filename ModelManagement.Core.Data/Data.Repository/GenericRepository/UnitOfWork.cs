using ModelManagement.Core.Data.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Repository.GenericRepository
{
    public class UnitOfWork
    {
        private ModelManagementContext dbContext = null;
        public ModelManagementContext DbContext
        {
            get { return dbContext; }
            set { dbContext = value; }
        }

        public UnitOfWork()
        {
            if (this.dbContext == null)
            {
                this.dbContext = new ModelManagementContext();
            }
        }

        public UnitOfWork(ModelManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int SaveChanges()
        {
            // Save changes with the default options
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (dbContext == null) return;
            dbContext.Dispose();
            dbContext = null;
        }
    }
}
