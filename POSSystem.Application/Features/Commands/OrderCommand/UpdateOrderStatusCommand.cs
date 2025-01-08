using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace POSSystem.Application.Features.Commands.OrderCommand
{
    public class UpdateOrderStatusCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public string NewStatus { get; set; }

        public UpdateOrderStatusCommand(int orderId, string newStatus)
        {
            OrderId = orderId;
            NewStatus = newStatus;
        }
    }
}
