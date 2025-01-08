using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using POSSystem.Domain.Interfaces;
using POSSystem.Domain.Interfaces.GenericInterface;
using POSSystem.Persistance.Repositories;

namespace POSSystem.Persistance.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<POSSystemDBContext>(option => option.UseSqlServer("Server=CPC-param-7Q3RT;Database=POSSystemDB2;Trusted_Connection=True;TrustServerCertificate=true;")
            .UseLazyLoadingProxies());

            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IOrderRepo), typeof(OrderRepository));
            return services;
        }
    }
}
