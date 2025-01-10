using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POSSystem.Application.DTO;
using POSSystem.Application.Features.Commands.Auth;
using POSSystem.Domain.Entities;
using POSSystem.Domain.Interfaces;
using POSSystem.Domain.Interfaces.GenericInterface;
using System.Threading.Tasks;

namespace POSSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public AuthController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] RegisterDTO model)
        {
            var user = await _sender.Send(new UserLoginRequest() { data = model});
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO model)
        {
            var user = await _sender.Send(new ResgisterCommand() { data = model });
            return Ok(user);
        }

    }
}
