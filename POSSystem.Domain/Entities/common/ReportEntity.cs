using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class ReportEntity
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }

        public int TotalSales { get; set; }

        public int TotalPurchases { get; set; }

        public int TotalOrders { get; set; }
    }
}
