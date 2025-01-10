using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Domain.Interfaces
{
    public interface IInventoryRepo
    {
       Task<bool> AddOrderToProduct(Guid productId, Guid quantity, List<Guid> orderId);

    }
}
