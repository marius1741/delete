using AutoMapper;
using delete.Business.ServiceInterfaces;
using delete.DTO;
using delete.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delete.Business.ServiceImplementations
{
    internal class Service<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> repository;
        private readonly IMapper mapper;
        public Service(IRepository<TEntity> repositoryInjection, IMapper mapperInjection)
        {
            repository = repositoryInjection;
            mapper = mapperInjection;
        }
        public ServiceDataResponse<TEntity> Add(TEntity entry)
        {
            var returnValue = new ServiceDataResponse<TEntity>();
            try
            {
                returnValue.Data = mapper.Map<TEntity>(repository.Add(mapper.Map<TEntity>(entry)));
                repository.SaveChanges();
                returnValue.Type = ResponseType.Success;
            }
            catch (Exception ex)
            {
                returnValue.Type = ResponseType.ServerError;
                returnValue.Message = ex.Message;
            }

            return returnValue;
        }

        public ServiceResponse Delete(int key)
        {
            ServiceResponse hasSucceded = new ServiceResponse();
            try
            {
                repository.Delete(key);
                hasSucceded.Type = ResponseType.Success;
            }
            catch (Exception ex)
            {
                hasSucceded.Type = ResponseType.ServerError;
                hasSucceded.Message = ex.Message;
            }

            return hasSucceded;
        }

        public ServiceDataResponse<IEnumerable<TEntity>> Get()
        {
            var returnValue = new ServiceDataResponse<IEnumerable<TEntity>>();
            returnValue.Data = repository.Get().Done();
            returnValue.Type = returnValue.Data == null ? ResponseType.NotFound : ResponseType.Success;
            returnValue.Message = returnValue.Data == null ? "Object not found" : string.Empty;

            return returnValue;
        }

        public ServiceDataResponse<TEntity> Get(int key)
        {
            var returnValue = new ServiceDataResponse<TEntity>();
            returnValue.Data = repository.Get(key);
            returnValue.Type = returnValue.Data == null ? ResponseType.NotFound : ResponseType.Success;
            returnValue.Message = returnValue.Data == null ? "Object not found" : string.Empty;

            return returnValue;
        }

        public ServiceDataResponse<TEntity> Update(TEntity entry)
        {
            var returnValue = new ServiceDataResponse<TEntity>();
            try
            {
                returnValue.Data = mapper.Map<TEntity>(repository.Update(mapper.Map<TEntity>(entry)));
                repository.SaveChanges();
                returnValue.Type = ResponseType.Success;
            }
            catch (Exception e)
            {
                returnValue.Type = ResponseType.ServerError;
                returnValue.Message = e.Message;
            }

            return returnValue;
        }
    }
}
