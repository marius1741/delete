using System.Collections.Generic;
using System.Linq;

namespace delete.Repository.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> entity);
        TEntity Get(int key);
        IQueryable<TEntity> Get();
        TEntity Update(TEntity entity);
        void Delete(int key);
        void SaveChanges();
    }
}
