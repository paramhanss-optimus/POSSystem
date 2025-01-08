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
        public int Id;
        public DeleteAsyncCommand(int id)
        {
            Id = id;
        }
    }
}


