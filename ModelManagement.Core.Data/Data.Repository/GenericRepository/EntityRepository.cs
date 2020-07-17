using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace ModelManagement.Core.Data.Data.Repository.GenericRepository
{
    public class EntityRepository<TEntity> where TEntity : Entity
    {
        private ModelManagementContext _context { get; set; }

        public EntityRepository()
        {
            this._context = new ModelManagementContext();
        }

        public EntityRepository(ModelManagementContext context)
        {
            this._context = context;
        }

        private DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public virtual TEntity Create(TEntity entity)
        {
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newEntity = DbSet.Add(entity);
                    _context.SaveChanges();
                    dbTransaction.Commit();
                    return newEntity;
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                    throw;
                }
            }
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<TEntity>();
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual TEntity Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual bool Delete(TEntity entity)
        {
            Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public virtual bool Delete(params object[] keys)
        {
            var entity = Find(keys);
            Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public virtual TEntity Update(TEntity entity)
        {
            entity.LastUpdatedStamp = DateTime.Now;
            var newEntity = _context.Entry(entity);
            newEntity.State = EntityState.Modified;
            if (_context.SaveChanges() <= 0) return null;
            newEntity.State = EntityState.Detached;
            return entity;
        }

        public virtual TEntity UpdateEntity(TEntity entity)
        {
            entity.LastUpdatedStamp = DateTime.Now;
            var newEntity = _context.Entry(entity);
            newEntity.State = EntityState.Modified;
            return entity;
        }

        public DbEntityEntry GetEntityEntry(TEntity entity)
        {
            return _context.Entry(entity);
        }

    }
}
