using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delete.Business.ServiceInterfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int key);
        TEntity Add(TEntity entry);
        TEntity Update(TEntity entry);
        void Delete(int key);
    }
}
