using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace POSSystem.Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
           
            return services;
        }
    }
}
