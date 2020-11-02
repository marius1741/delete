using delete.DTO;
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
        ServiceDataResponse<Delete> Get(int id);
        ServiceDataResponse<DeleteDTO> Add(DeleteDTO entry);
        Delete Update(Delete entry);
        ServiceResponse Delete(int id);
    }
}
