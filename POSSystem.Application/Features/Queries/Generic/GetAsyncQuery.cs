using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Queries.Generic
{

    public class GetAsyncQuery<T> : IRequest<IEnumerable<T>> where T : class
    {

    }
}
