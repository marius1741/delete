using Microsoft.Extensions.DependencyInjection;

namespace delete.Business
{
    public static class Startup
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            Repository.Startup.Configure(services, connectionString);

            //services.AddScoped<IDeleteRepository, DeleteRepository>();
        }
    }
}
