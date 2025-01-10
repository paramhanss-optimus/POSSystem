using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class UserEntity
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
       
        public string Role { get; set; } = "user";

        public Guid? AdminId { get; set; }
        public Guid? CashierId { get; set; }

        public Guid? CustomerId { get; set; }

        public virtual AdminEntity? Admin { get; set; }

        public virtual CashierEntity? Cashier { get; set; }

        public virtual CustomerEntity? Customer { get; set; }


    }
}
