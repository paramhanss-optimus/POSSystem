using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using POSSystem.Application.Features.Commands.Generic;
using POSSystem.Application.Features.Handlers.Generic;
using POSSystem.Application.Features.Queries.Generic;
using POSSystem.Application.Mapping;

namespace POSSystem.Application
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceExtension).Assembly));
                services.AddAutoMapper(typeof(InventoryMapping));
                services.AddAutoMapper(typeof(OrderMapping));
                services.AddAutoMapper(typeof(CustomerMApping));


            RegisterGenericHandlers(services);

            return services;
            }

        private static void RegisterGenericHandlers(IServiceCollection services)
        {
            Assembly assembly = Assembly.Load("POSSystem.Domain");
            string targetNamespace = "POSSystem.Domain.Entities";


            Type[] types = assembly.GetTypes();

            var classTypes = types
                .Where(t => t.IsClass && t.Namespace == targetNamespace)
                .ToArray();

            foreach (var item in classTypes)
            {
                var createRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(CreateAsyncCommand<>).MakeGenericType(item), typeof(bool));
                var createCommandHandlerType = typeof(CreateAsyncCommandHandler<>).MakeGenericType(item);

                var getRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(GetAsyncQuery<>).MakeGenericType(item), typeof(IEnumerable<>).MakeGenericType(item));
                var getQueryHandlerType = typeof(GetAsyncQueryHandler<>).MakeGenericType(item);

                var deleteRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(DeleteAsyncCommand<>).MakeGenericType(item), typeof(bool));
                var deleteCommandHandlerType = typeof(DeleteAsyncCommandHandler<>).MakeGenericType(item);

                var updateRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(UpdateAsyncCommand<>).MakeGenericType(item), typeof(bool));
                var updateCommandHandlerType = typeof(UpdateAsyncCommandHandler<>).MakeGenericType(item);


                services.AddTransient(createRequestHandlerType, createCommandHandlerType);
                services.AddTransient(getRequestHandlerType, getQueryHandlerType);
                services.AddTransient(deleteRequestHandlerType, deleteCommandHandlerType);
                services.AddTransient(updateRequestHandlerType, updateCommandHandlerType);
            }
        }
    }
    }

