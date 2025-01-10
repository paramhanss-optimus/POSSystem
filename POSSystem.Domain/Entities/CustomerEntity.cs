using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Domain.Entities
{
    public class CustomerEntity
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
       
        public virtual UserEntity? User { get; set; }

        public virtual ICollection<OrderEntity>? Orders { get; set; }
    }
}
