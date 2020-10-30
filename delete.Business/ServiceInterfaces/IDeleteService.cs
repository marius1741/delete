using delete.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delete.Business.ServiceInterfaces
{
    public interface IDeleteService
    {
        IEnumerable<Delete> Get();
        Delete Get(int id);
        Delete Add(Delete entry);
        Delete Update(Delete entry);
        bool Delete(int id);
    }
}
