using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Application.DTO
{
    public class InventoryOrderDTO
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
