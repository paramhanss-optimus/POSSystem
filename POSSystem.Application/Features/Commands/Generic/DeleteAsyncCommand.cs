using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Commands.Generic
{
    public class DeleteAsyncCommand<T> : IRequest<bool> where T : class
    {
        public Guid Id;
        public DeleteAsyncCommand(Guid id)
        {
            Id = id;
        }
    }
}


