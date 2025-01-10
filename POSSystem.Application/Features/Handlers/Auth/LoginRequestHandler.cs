using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Application.Features.Commands.Auth;
using POSSystem.Domain.Interfaces;

namespace POSSystem.Application.Features.Handlers.Auth
{
    public class LoginRequestHandler : IRequestHandler<UserLoginRequest, string>
    {
        private readonly IAuth _authService;
        public LoginRequestHandler(IAuth authService)
        {
            _authService = authService;
        }

        public async Task<string> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            var jwtToken = await _authService.AuthenticateUSerAsync(request.data.Email, request.data.Password);
            if (jwtToken != null)
            {
                return jwtToken;
            }
            else
            {
                throw new Exception("Invalid Login");
            }

        }
    }
}