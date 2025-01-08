using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Domain.Entities
{
    public class RoleEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ICollection<PermissionEntity> Permissions { get; set; }

    }
}
