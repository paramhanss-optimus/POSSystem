using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Domain.Interfaces
{
    public interface IInventoryRepo
    {
       Task<bool> AddOrderToProduct(int productId, int quantity, List<int> orderId);

    }
}
