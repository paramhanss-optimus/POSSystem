using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Queries.Generic
{
    public class GetbyIdAsyncQuery<T> : IRequest<T> where T : class
    {
        public int id { get; set; }

        public GetbyIdAsyncQuery(int ID)
        {
            ID = id;
        }
    }


}
