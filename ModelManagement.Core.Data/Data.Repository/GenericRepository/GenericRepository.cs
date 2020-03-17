using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Repository.GenericRepository
{

    public static class SharedUow
    {
        private static UnitOfWork uow;

        public static UnitOfWork Uow
        {
            get
            {
                if (uow == null)
                {
                    uow = new UnitOfWork();
                }
                return uow;
            }
        }
    }

    public class GenericRepository<TEntity> where TEntity : CommonEntity
    {
        public static UnitOfWork sharedUow;
        public UnitOfWork uow;
        private bool shareContext = false;

        public GenericRepository()
        {
            uow = SharedUow.Uow;
        }

        public GenericRepository(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public DbSet<TEntity> DbSet => uow.DbContext.Set<TEntity>();

        public void Dispose()
        {
            if (shareContext)
                uow?.Dispose();
        }

        public virtual IQueryable<TEntity> All()
        {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<TEntity>();
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? DbSet.Where(filter).AsQueryable() : DbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }
        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public virtual TEntity Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual TEntity FindUpdate(params object[] keys)
        {
            var context = uow.DbContext;
            var TObject = DbSet.Find(keys);
            if (TObject != null)
            {
                context.Entry(TObject).State = EntityState.Detached;
                return TObject;
            }
            else
            {
                return null;
            }
        }


        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        //public bool Create(TEntity TObject)
        //{
        //    var newEntry = DbSet.Add(TObject);
        //    if (!shareContext)
        //        if (uow.SaveChanges() > 0)
        //        {
        //            return true;
        //        }
        //    return false;
        //}

        public virtual TEntity CreateTrans(TEntity TObject)
        {

            using (var trans = uow.DbContext.Database.BeginTransaction())
            {
                try
                {
                    TEntity newEntity = DbSet.Add(TObject);
                    if (!shareContext)
                    {
                        if (uow.SaveChanges() > 0)
                        {
                            trans.Commit();
                            return newEntity;
                        }
                    }
                }
                catch (Exception)
                {
                    trans.Rollback();
                    uow.DbContext = new ModelManagementContext();
                    throw new Exception();
                }
            }
            return null;
        }

        public virtual TEntity Create(TEntity TObject)
        {
            using (var context = new ModelManagementContext())
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        TEntity newE = context.Set<TEntity>().Add(TObject);
                        context.SaveChanges();
                        dbTransaction.Commit();
                        return newE;
                    }
                    catch (Exception exception)
                    {
                        dbTransaction.Rollback();
                        throw exception;
                    }
                }
            }
            //using (var dbTransaction = uow.DbContext.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        TEntity newEntity = DbSet.Add(TObject);
            //        if (!shareContext)
            //        {
            //            if (uow.SaveChanges() > 0)
            //            {
            //                dbTransaction.Commit();
            //                return newEntity;
            //            }
            //        }
            //    }
            //    catch (Exception exception)
            //    {
            //        dbTransaction.Rollback();
            //        uow = new UnitOfWork();
            //        throw exception;
            //    }
            //}
            //TEntity newEntity = DbSet.Add(TObject);
            //if (!shareContext)
            //{
            //    if (uow.SaveChanges() > 0)
            //    {
            //        return newEntity;
            //    }
            //}
        }

        public virtual bool CreateBulk(List<TEntity> TObjects)
        {
            using (var dbTransaction = uow.DbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var tObject in TObjects)
                    {
                        DbSet.Add(tObject);
                    }
                    if (!shareContext)
                    {
                        if (uow.SaveChanges() > 0)
                        {
                            dbTransaction.Commit();
                            return true;
                        }
                    }
                }
                catch (Exception exception)
                {
                    dbTransaction.Rollback();
                    uow = new UnitOfWork();
                    throw exception;
                }
            }
            return false;
        }

        public virtual int Count
        {
            get
            {
                return DbSet.Count();
            }
        }
        //public virtual bool Delete(TEntity TObject)
        //{
        //    DbSet.Remove(TObject);
        //    if (!shareContext)
        //        if (uow.SaveChanges() > 0)
        //            return true;
        //    return false;
        //}
        public virtual TEntity Delete(TEntity TObject)
        {
            TEntity newEntity = DbSet.Remove(TObject);
            if (!shareContext)
            {
                if (uow.SaveChanges() > 0)
                {
                    return newEntity;
                }
            }
            return null;
        }
        //public virtual bool Update(TEntity TObject)
        //{
        //    var entry = uow.DbContext.Entry(TObject);
        //    DbSet.Attach(TObject);
        //    entry.State = EntityState.Modified;
        //    if (!shareContext)
        //        return uow.SaveChanges() >= 0;
        //    return false;
        //}
        public virtual TEntity Update(TEntity TObject)
        {
            TObject.LastUpdatedStamp = DateTime.Now;
            ModelManagementContext context = uow.DbContext;
            var entry = uow.DbContext.Entry(TObject);
            TEntity newEntity = DbSet.Attach(TObject);
            entry.State = EntityState.Modified;
            if (!shareContext)
            {
                if (uow.SaveChanges() >= 0)
                {
                    context.Entry(TObject).State = EntityState.Detached;
                    return newEntity;
                }
            }
            return null;
        }
        public virtual bool Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            if (!shareContext)
                if (uow.SaveChanges() > 0)
                    return true;
            return false;
        }
    }
}
