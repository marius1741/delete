using delete.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace delete.Repository.RepositoryImplementations
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository(Entities entityContext)
        {
            EntityContext = entityContext ?? throw new ArgumentNullException(nameof(entityContext), "you's stupid");
        }
        protected Entities EntityContext { get; private set; }
        public virtual TEntity Add(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity you were trying to add was null");
            }

            var entitySet = EntityContext.Set<TEntity>();
            entitySet.Add(entity);
            return entity;
        }
        public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity you were trying to add was null");
            }

            var adc = EntityContext.Configuration.AutoDetectChangesEnabled;
            try
            {
                //disable autodetect changed on bulk operations in order to signifiantly improve performance
                EntityContext.Configuration.AutoDetectChangesEnabled = false;
                var entitySet = EntityContext.Set<TEntity>();
                entitySet.AddRange(entity);
            }
            finally
            {
                EntityContext.Configuration.AutoDetectChangesEnabled = adc;
            }
            return entity;
        }
        public virtual void Delete(int key)
        {
            var entitySet = EntityContext.Set<TEntity>();
            var entityToDelete = entitySet.Find(key);
            
            if(entityToDelete != null)
            {
                entitySet.Remove(entityToDelete);
            }
        }
        public virtual TEntity Get(int key)
        {
            var entitySet = EntityContext.Set<TEntity>();
            var entityToGet = entitySet.Find(key);
            
            return entityToGet;
        }
        public virtual IQuerySpecifications<TEntity> Get()
        {
            var entitySet = EntityContext.Set<TEntity>();
            return (IQuerySpecifications<TEntity>)entitySet;
        }
        public virtual void SaveChanges()
        {
            EntityContext.SaveChanges();
        }
        public virtual TEntity Update(TEntity entity)
        {
            //I like this better than what I do
            var entitySet = EntityContext.Set<TEntity>();
            var entry = EntityContext.Entry(entity);

            if (entry.State == EntityState.Detached)
                entitySet.Attach(entity);
            entry.State = EntityState.Modified;

            return entity;

            //var dbSet = EntityContext.Set<TEntity>();
            //dbSet.Attach(entity);
            //var entry = EntityContext.Entry(entity);
            //entry.State = EntityState.Modified;
            //return entity;
        }
    }
}
