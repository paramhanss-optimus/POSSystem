using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Commands.Generic
{
    public class CreateAsyncCommand <T> : IRequest<bool> where T : class
    {
        public T Entity { get; set; }

        public CreateAsyncCommand(T entity)
        {
            Entity = entity;
        }
    }
}
