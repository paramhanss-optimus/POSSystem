using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class OrderEntity
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public virtual ICollection<OrderInventory>? OrderInventory { get; set; }
        public Guid? CustomerId{ get; set; }
        public virtual CustomerEntity? Customer { get; set; }

}
}
