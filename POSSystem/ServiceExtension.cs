using POSSystem.Application;
using POSSystem.Infrastructure;
using POSSystem.Persistance.Extension;

namespace POSSystem
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddAPI(this IServiceCollection services)
        {

             services.AddApplication()
                .AddInfra()
                .AddPersistence();


            return services;
        }
    }
}
