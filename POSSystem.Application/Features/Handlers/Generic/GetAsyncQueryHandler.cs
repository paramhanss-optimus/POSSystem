using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Application.Features.Commands.Generic;
using POSSystem.Application.Features.Queries.Generic;
using POSSystem.Domain.Interfaces.GenericInterface;

namespace POSSystem.Application.Features.Handlers.Generic
{
    public class GetAsyncQueryHandler<T> : IRequestHandler<GetAsyncQuery<T>,IEnumerable<T> > where T : class
    {

        private readonly IGenericRepo<T> _repository;

        public GetAsyncQueryHandler(IGenericRepo<T> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<T>> Handle(GetAsyncQuery<T> request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync();
        }
    }
}
