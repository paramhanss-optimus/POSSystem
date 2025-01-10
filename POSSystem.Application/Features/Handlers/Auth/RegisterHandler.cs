using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POS.Utilities;
using POSSystem.Application.Features.Commands.Auth;
using POSSystem.Domain.Entities;
using POSSystem.Domain.Interfaces;

namespace POSSystem.Application.Features.Handlers.Auth
{
    public class RegisterHandler : IRequestHandler<ResgisterCommand, string>
    {
        private readonly IAuth _authService;
        public RegisterHandler(IAuth authService)
        {
            _authService = authService;
        }

        public Task<string> Handle(ResgisterCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = _authService.RegisterUserAsync(new UserEntity()
            {
                Email = request.data.Email,
                Password = EnCryptingService.EncryptPassword(request.data.Password),
            });

            if (jwtToken != null)
            {
                return jwtToken;
            }
            else
            {
                throw new Exception("Invalid Registration");
            }
        }
    }



}