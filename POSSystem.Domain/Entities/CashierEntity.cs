using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Domain.Entities
{
    public class CashierEntity
    {
        public int CashierId { get; set; }
        public string CashierName { get; set; }
       
        public virtual UserEntity User { get; set; }
    }
}
