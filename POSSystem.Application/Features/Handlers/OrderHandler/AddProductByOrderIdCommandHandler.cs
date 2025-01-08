using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using POSSystem.Application.Features.Commands.OrderCommand;
using POSSystem.Domain.Entities;
using POSSystem.Domain.Interfaces;

namespace POSSystem.Application.Features.Handlers.OrderHandler
{
    internal class AddProductByOrderIdCommandHandler : IRequestHandler<AddProductByOrderIdCommand, bool>
    {
        private readonly IOrderRepo _orderRepo;
        public AddProductByOrderIdCommandHandler(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public async Task<bool> Handle(AddProductByOrderIdCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepo.AddProductsToOrder(request.OrderId, request.productIds);
        }
    }

}
