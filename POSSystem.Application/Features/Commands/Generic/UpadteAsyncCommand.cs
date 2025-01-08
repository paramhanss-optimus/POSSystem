using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Commands.Generic
{
    public class UpdateAsyncCommand<T> : IRequest<bool>
    {
        public T Entity { get; }

        public UpdateAsyncCommand(T entity)
        {
            Entity = entity;
        }
    }
}
