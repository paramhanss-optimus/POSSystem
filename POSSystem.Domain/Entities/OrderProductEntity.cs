using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Domain.Entities
{
    public class OrderProductEntity
    {
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual OrderEntity Order { get; set; }

        public virtual InventoryEntity Product { get; set; }
    }

}
