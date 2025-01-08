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
    public class CustomerController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public CustomerController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var result = await _sender.Send(new GetAsyncQuery<CustomerEntity>());
            var resultDTO = _mapper.Map<IEnumerable<CustomerDTO>>(result);
            return Ok(resultDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CraeteCustomer([FromBody] CustomerDTO inventoryDTO)
        {
            var entity = _mapper.Map<CustomerEntity>(inventoryDTO);
            var result = await _sender.Send(new CreateAsyncCommand<CustomerEntity>(entity));
            if (!result)
            {
                return BadRequest("No Customer Created");
            }
            return Ok("Customer Created Successfully");
        }


        [HttpDelete("{custid:int}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int custid, CancellationToken ct)
        {
            var result = await _sender.Send(new DeleteAsyncCommand<CustomerEntity>(custid), ct);
            if (result == false)
            {
                return BadRequest("Employee Not found !!");
            }
            return Ok("Employee Deleted Successfully !!");
        }




        [HttpPut("{custid:int}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int custId, [FromBody] CustomerDTO ord, CancellationToken ct)
        {
            var custEntity = _mapper.Map<CustomerEntity>(ord);
            custEntity.CustomerId = custId;
            var result = await _sender.Send(new UpdateAsyncCommand<CustomerEntity>(custEntity), ct);
            if (result == false)
            {
                return BadRequest("Customer Not Updated !!");
            }
            return Ok("Customer Updated Successfully !!");
        }


    }
}
