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
        Task<bool> AddProductsToOrder (int orderId, List<int> productId);
        Task<bool> UpdateOrderStatus(int orderId, int status);
        Task<IEnumerable<OrderEntity>> GetOrderByProductId(int productId);

    }
}
