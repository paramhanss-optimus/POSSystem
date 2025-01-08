using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Application.DTO
{
    public class OrderDTO
    {
        public DateTime OrderDate { get; set; }
        public int OrderTotal { get; set; }
        public int OrderStatus { get; set; }
    }
}
