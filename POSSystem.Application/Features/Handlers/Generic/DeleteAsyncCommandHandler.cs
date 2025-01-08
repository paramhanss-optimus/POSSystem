using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Application.Features.Commands.Generic;
using POSSystem.Domain.Interfaces.GenericInterface;

namespace POSSystem.Application.Features.Handlers.Generic
{
   
    public class DeleteAsyncCommandHandler<T> : IRequestHandler<DeleteAsyncCommand<T>, bool> where T : class
    {

        private readonly IGenericRepo<T> _repository;

        public DeleteAsyncCommandHandler(IGenericRepo<T> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteAsyncCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}



  