using delete.DTO;
using delete.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delete.Business.ServiceInterfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        ServiceDataResponse<IEnumerable<TEntity>> Get();
        ServiceDataResponse<TEntity> Get(int key);
        ServiceDataResponse<TEntity> Add(TEntity entry);
        ServiceDataResponse<TEntity> Update(TEntity entry);
        ServiceResponse Delete(int key);
    }
}
