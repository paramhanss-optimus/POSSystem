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
        public int OrderId;
        public List<int>? productIds;
       

        public AddProductByOrderIdCommand(int orderId, List<int>? prodIds)
        {
            OrderId = orderId;
            productIds = prodIds;
            
        }

        
       
    }
}
