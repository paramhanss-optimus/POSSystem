
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POSSystem.Application.DTO;
using POSSystem.Application.Features.Commands.Generic;
using POSSystem.Application.Features.Commands.OrderCommand;
using POSSystem.Application.Features.Queries.Generic;
using POSSystem.Domain.Entities;

namespace POSSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public OrderController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var result = await _sender.Send(new GetAsyncQuery<OrderEntity>());
            var resultDTO = _mapper.Map<IEnumerable<OrderDTO>>(result);
            return Ok(resultDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] OrderDTO orderDTO)
        {
            var entity = _mapper.Map<OrderEntity>(orderDTO);
            var result = await _sender.Send(new CreateAsyncCommand<OrderEntity>(entity));
            if (!result)
            {
                return BadRequest("No Order Created");
            }
            return Ok("Order Created Successfully");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _sender.Send(new DeleteAsyncCommand<OrderEntity>(id));
            if (!result)
            {
                return BadRequest("No Order Deleted");
            }
            return Ok(" Order Deleted Successfully");
        }


        [HttpPost("AddProductsToOrder")]
        public async Task<IActionResult> AddProductsToOrder([FromRoute]int orderId, [FromBody] List<int> productIds)
        {
            var result = await _sender.Send(new AddProductByOrderIdCommand(orderId, productIds));
            if (!result)
            {
                return BadRequest("Products could not be added to the order");
            }
            return Ok("Products added to the order successfully");
        }

        [HttpPut("{custid:int}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int orderId, [FromBody] OrderDTO ord, CancellationToken ct)
        {
            var orderEntity = _mapper.Map<OrderEntity>(ord);
            orderEntity.OrderId = orderId;
            var result = await _sender.Send(new UpdateAsyncCommand<OrderEntity>(orderEntity), ct);
            if (result == false)
            {
                return BadRequest("Customer Not Updated !!");
            }
            return Ok("Customer Updated Successfully !!");
        }


    }
}
