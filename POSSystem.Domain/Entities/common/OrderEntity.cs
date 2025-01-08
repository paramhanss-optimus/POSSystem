using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class OrderEntity
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderTotal { get; set; }
        public int OrderStatus { get; set; }

        public virtual ICollection<OrderProductEntity>? OrderPro { get; set; }
        public int? CustomerId{ get; set; }
        public virtual CustomerEntity? Customer { get; set; }

}
}
