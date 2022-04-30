using BrainGym.Application.Calls.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrainGym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var registerResult = await _mediator.Send(command);

            if (registerResult.Secceeded)
            {
                return Ok(registerResult.Result);
            }

            return BadRequest(registerResult.ErrorList);
        }
    }
}
