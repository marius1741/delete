using delete.Business.ServiceInterfaces;
using delete.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delete.Business.ServiceImplementations
{
    internal class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> repository;
        public Service(IRepository<TEntity> repositoryInjection)
        {
            repository = repositoryInjection;
        }
        public TEntity Add(TEntity entry)
        {
            var returnValue = repository.Add(entry);
            repository.SaveChanges();

            return returnValue;
        }

        public void Delete(int key)
        {
            repository.Delete(key);
            repository.SaveChanges();
        }

        public IEnumerable<TEntity> Get()
        {
            return repository.Get().Done();
        }

        public TEntity Get(int key)
        {
            return repository.Get(key);
        }

        public TEntity Update(TEntity entry)
        {
            var value = repository.Update(entry);
            repository.SaveChanges();

            return value;
        }
    }
}
