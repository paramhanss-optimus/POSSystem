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
    public class UpdateAsyncCommandHandler<T> : IRequestHandler<UpdateAsyncCommand<T>, bool> where T : class
    {
        private readonly IGenericRepo<T> _repository;

        public UpdateAsyncCommandHandler(IGenericRepo<T> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateAsyncCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.Entity);
        }
    }
}
