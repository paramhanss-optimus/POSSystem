using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POSSystem.Application.Features.Queries.OrderQueries
{
    public class GetOrderByProductIdQuery
    {
        public int ProductId { get; set; }
        public GetOrderByProductIdQuery(int productId)
        {
            ProductId = productId;
        }

    }
}
