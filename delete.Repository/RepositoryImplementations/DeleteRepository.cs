using delete.Repository.RepositoryInterfaces;

namespace delete.Repository.RepositoryImplementations
{
    internal class DeleteRepository : Repository<Delete>, IDeleteRepository
    {
        public DeleteRepository(Entities entityContext) : base(entityContext)
        {
        }
    }
}
