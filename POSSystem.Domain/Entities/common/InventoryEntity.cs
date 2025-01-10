using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class InventoryEntity
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductStock { get; set; }
        int ProductPrice { get; set; }

        public virtual ICollection<OrderInventory>? InventoryOrder { get; set; }


    }
}
