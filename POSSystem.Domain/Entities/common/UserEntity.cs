using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public int? RoleId { get; set; }
        public int? AdminId { get; set; }
        public int? CashierId { get; set; }

        public int? CustomerId { get; set; }

        public virtual RoleEntity? Role { get; set; }

        public virtual AdminEntity? Admin { get; set; }

        public virtual CashierEntity? Cashier { get; set; }

        public virtual CustomerEntity? Customer { get; set; }


    }
}
