using delete.Repository.RepositoryImplementations;
using delete.Repository.RepositoryInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace delete.Repository
{
    public static class Startup
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped(factory =>
            {
                return new Entities(connectionString);
            });
        }
    }
}