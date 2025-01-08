using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POSSystem.Domain.Entities;
using POSSystem.Domain.Interfaces;

namespace POSSystem.Persistance.Repositories
{
    public class OrderRepository : GenericRepository<OrderEntity>, IOrderRepo 
    {
        private readonly POSSystemDBContext _context;

        public OrderRepository(POSSystemDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddProductsToOrder(int orderId, List<int> productId)
        {
            var order = await GetByIdAsync(orderId);
            if (order == null) return false;

            var productList = await _context.Inventories.Where(x => productId.Contains(x.ProductId)).ToListAsync();

            foreach (var product in productList)
            {
                if (!order.OrderPro.Any(op => op.ProductId == product.ProductId))
                {
                    order.OrderPro.Add(new OrderProductEntity
                    {
                        OrderId = orderId,
                        ProductId = product.ProductId,
                      
                    });
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<IEnumerable<OrderEntity>> GetOrderByProductId(int productId)
        {
            return await _context.OrderProducts
                .Where(op => op.ProductId == productId)
                .Select(op => op.Order)
                .ToListAsync();
        }


        public async Task<bool> UpdateOrderStatus(int orderId, int status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return false;
            }
            order.OrderStatus = status;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
