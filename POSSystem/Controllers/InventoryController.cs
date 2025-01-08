using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POSSystem.Application.DTO;
using POSSystem.Application.Features.Commands.Generic;
using POSSystem.Application.Features.Queries.Generic;
using POSSystem.Domain.Entities;
using POSSystem.Domain.Entities;

namespace POSSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public InventoryController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var result = await _sender.Send(new GetAsyncQuery<InventoryEntity>());
            var resultDTO = _mapper.Map<IEnumerable<InventoryDTO>>(result);
            return Ok(resultDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] InventoryDTO inventoryDTO)
        {
            var entity = _mapper.Map<InventoryEntity>(inventoryDTO);
            var result = await _sender.Send(new CreateAsyncCommand<InventoryEntity>(entity));
            if (!result)
            {
                return BadRequest("No Product Created");
            }
            return Ok("Product Created Successfully");
        }

        [HttpDelete("{prodid:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int prodid)
        {
            var result = await _sender.Send(new DeleteAsyncCommand<InventoryEntity>(prodid));
            if (!result)
            {
                return BadRequest("No Product Deleted");
            }
            return Ok("Product Deleted Successfully");
        }


        [HttpPut("{prodId:int}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int prodId, [FromBody] InventoryDTO ord, CancellationToken ct)
        {
            var prodEntity = _mapper.Map<InventoryEntity>(ord);
            prodEntity.ProductId = prodId;
            var result = await _sender.Send(new UpdateAsyncCommand<InventoryEntity>(prodEntity), ct);
            if (result == false)
            {
                return BadRequest("Customer Not Updated !!");
            }
            return Ok("Customer Updated Successfully !!");
        }



    }
}
