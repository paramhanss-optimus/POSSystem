using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSSystem.Domain.Entities;

namespace POSSystem.Domain.Interfaces
{
    public interface IAuth
    {
        public Task<string> AuthenticateUSerAsync(string email, string password);
        public Task<string> RegisterUserAsync(UserEntity newUSer);
    }
}
