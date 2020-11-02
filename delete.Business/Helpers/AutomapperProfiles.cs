using AutoMapper;
using delete.DTO;
using delete.Repository;

namespace delete.Business.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Delete, DeleteDTO>();
            CreateMap<DeleteDTO, Delete>();
        }
    }
}
