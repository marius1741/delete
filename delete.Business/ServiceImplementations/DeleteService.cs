using delete.Business.ServiceInterfaces;
using delete.Repository;
using delete.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace delete.Business.ServiceImplementations
{
    internal class DeleteService : IDeleteService
    {
        private readonly IDeleteRepository deleteRepository;
        public DeleteService(IDeleteRepository deleteRepositoryInjection)
        {
            deleteRepository = deleteRepositoryInjection;
        }
        public Delete Add(Delete entry)
        {
            var returnValue = deleteRepository.Add(entry);
            deleteRepository.SaveChanges();
            return returnValue;
        }
        public bool Delete(int id)
        {
            bool hasSucceded = false;
            try
            {
                deleteRepository.Delete(id);
                hasSucceded = true;
            }
            catch (Exception ex)
            {
                //don't ever do this
            }
            return hasSucceded;
        }
        public Delete Get(int id)
        {
            //return deleteRepository.Get().Where(s => s.OtherInfo.Contains(id.ToString())).Done().FirstOrDefault();
            //return deleteRepository.Get().Where(s => s.Id == id).Done().FirstOrDefault();
            return deleteRepository.Get(id);
        }

        public IEnumerable<Delete> Get()
        {
            return deleteRepository.Get().Done();
        }

        public Delete Update(Delete entry)
        {
            var value = deleteRepository.Update(entry);
            deleteRepository.SaveChanges();
            return value;
        }
    }
}
