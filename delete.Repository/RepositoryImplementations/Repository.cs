using delete.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;

namespace delete.Repository.RepositoryImplementations
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository(Entities entityContext)
        {
            EntityContext = entityContext ?? throw new ArgumentNullException(nameof(entityContext), "you's stupid");
        }
        protected Entities EntityContext { get; private set; }
        public TEntity Add(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity you were trying to add was null");
            }

            var entitySet = EntityContext.Set<TEntity>();
            entitySet.Add(entity);
            return entity;
        }
        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity you were trying to add was null");
            }

            var entitySet = EntityContext.Set<TEntity>();
            entitySet.AddRange(entity);
            return entity;
        }
        public void Delete(int key)
        {
            var entitySet = EntityContext.Set<TEntity>();
            var entityToDelete = entitySet.Find(key);
            
            if(entityToDelete != null)
            {
                entitySet.Remove(entityToDelete);
            }
        }
        public TEntity Get(int key)
        {
            var entitySet = EntityContext.Set<TEntity>();
            var entityToGet = entitySet.Find(key);
            
            return entityToGet;
        }
        public IQueryable<TEntity> Get()
        {
            var entitySet = EntityContext.Set<TEntity>();
            return entitySet;
        }
        public void SaveChanges()
        {
            EntityContext.SaveChanges();
        }
        public TEntity Update(TEntity entity)
        {
            var entitySet = EntityContext.Set<TEntity>();
            var entry = EntityContext.Entry(entity);
            
            if (entry.State == EntityState.Detached)
                entitySet.Attach(entity);
            entry.State = EntityState.Modified;
            
            return entity;
        }
    }
}
