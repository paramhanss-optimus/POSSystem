using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Domain.Entities
{
    public class OrderInventory
    {
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual OrderEntity? Order { get; set; }

        public virtual InventoryEntity? Product { get; set; }
    }

}
