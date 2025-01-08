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
    public class CreateAsyncCommandHandler<T> : IRequestHandler<CreateAsyncCommand<T>, bool> where T : class
    {

        private readonly IGenericRepo<T> _repository;

        public CreateAsyncCommandHandler(IGenericRepo<T> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(CreateAsyncCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repository.CreateAsync(request.Entity);
        }
    }
   
}
