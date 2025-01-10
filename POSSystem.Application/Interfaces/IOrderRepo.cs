using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Domain.Interfaces
{
    public interface IOrderRepo
    {
        Task<bool> AddProductsToOrder (Guid orderId, List<Guid> productId);
        Task<bool> UpdateOrderStatus(Guid orderId, string status);
        Task<IEnumerable<OrderEntity>> GetOrderByProductId(Guid productId);

    }
}
