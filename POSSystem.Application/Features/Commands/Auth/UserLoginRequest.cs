using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Application.DTO;

namespace POSSystem.Application.Features.Commands.Auth
{
    public class UserLoginRequest : IRequest<string>
    {
        public RegisterDTO data { get; set; }
        public UserLoginRequest()
        {

        }
    }
}
