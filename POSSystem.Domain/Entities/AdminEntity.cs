using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Domain.Entities
{
    public class AdminEntity
    {
        public Guid AdminId { get; set; }
        public string AdminName { get; set; }

        public virtual UserEntity User { get; set; }

    }
}
