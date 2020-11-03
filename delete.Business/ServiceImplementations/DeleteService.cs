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
    internal class DeleteService : Service<Delete>, IDeleteService
    {
        private readonly IRepository<Delete> _deleteRepository;
        private readonly IMapper _mapper;
        public DeleteService(IRepository<Delete> deleteRepositoryInjection, IMapper mapperInjection) : base (deleteRepositoryInjection, mapperInjection) 
        {
            _deleteRepository = deleteRepositoryInjection;
            _mapper = mapperInjection;
        }

        public ServiceDataResponse<DeleteDTO> Add(DeleteDTO entry)
        {
            throw new NotImplementedException();
        }

        public ServiceDataResponse<DeleteDTO> Update(DeleteDTO entry)
        {
            throw new NotImplementedException();
        }
    }
}
