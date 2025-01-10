using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Commands.OrderCommand
{
    public class AddProductByOrderIdCommand : IRequest<bool>
    {
        public Guid OrderId;
        public List<Guid>? productIds;
       

        public AddProductByOrderIdCommand(Guid orderId, List<Guid>? prodIds)
        {
            OrderId = orderId;
            productIds = prodIds;
            
        }

        
       
    }
}
