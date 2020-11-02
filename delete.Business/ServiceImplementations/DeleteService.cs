using AutoMapper;
using delete.Business.ServiceInterfaces;
using delete.DTO;
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
        private readonly IMapper mapper;
        public DeleteService(IDeleteRepository deleteRepositoryInjection, IMapper mapperInjection)
        {
            deleteRepository = deleteRepositoryInjection;
            mapper = mapperInjection;
        }
        public ServiceDataResponse<DeleteDTO> Add(DeleteDTO entry)
        {
            var returnValue = new ServiceDataResponse<DeleteDTO>();
            try
            {
                returnValue.Data = mapper.Map<DeleteDTO>(deleteRepository.Add(mapper.Map<Delete>(entry)));
                deleteRepository.SaveChanges();
                returnValue.Type = ResponseType.Success;
            }
            catch(Exception ex)
            {
                returnValue.Type = ResponseType.ServerError;
                returnValue.Message = ex.Message;
            }
            return returnValue;
        }
        public ServiceResponse Delete(int id)
        {
            ServiceResponse hasSucceded = new ServiceResponse();
            try
            {
                deleteRepository.Delete(id);
                hasSucceded.Type = ResponseType.Success;
            }
            catch (Exception ex)
            {
                hasSucceded.Type = ResponseType.ServerError;
                hasSucceded.Message = ex.Message;
            }
            return hasSucceded;
        }
        public ServiceDataResponse<Delete> Get(int id)
        {
            //return deleteRepository.Get().Where(s => s.OtherInfo.Contains(id.ToString())).Done().FirstOrDefault();
            //return deleteRepository.Get().Where(s => s.Id == id).Done().FirstOrDefault();

            var returnValue = new ServiceDataResponse<Delete>();
            returnValue.Data = deleteRepository.Get(id);
            returnValue.Type = returnValue.Data == null ? ResponseType.NotFound : ResponseType.Success;
            returnValue.Message = returnValue.Data == null ? "Object not found" : string.Empty;

            return returnValue;
        }

        public ServiceDataResponse<IEnumerable<Delete>> Get()
        {
            var returnValue = new ServiceDataResponse<IEnumerable<Delete>>();
            returnValue.Data = deleteRepository.Get().Done();
            returnValue.Type = returnValue.Data == null ? ResponseType.NotFound : ResponseType.Success;
            returnValue.Message = returnValue.Data == null ? "Object not found" : string.Empty;

            return returnValue;
        }

        public ServiceDataResponse<DeleteDTO> Update(DeleteDTO entry)
        {
            var returnValue = new ServiceDataResponse<DeleteDTO>();
            try
            {
                returnValue.Data = mapper.Map<DeleteDTO>(deleteRepository.Update(mapper.Map<Delete>(entry)));
                deleteRepository.SaveChanges();
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
