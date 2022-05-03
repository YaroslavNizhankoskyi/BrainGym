using BrainGym.Application.Calls.Factors.Commands.Delete;
using BrainGym.Application.Calls.Factors.Commands.Post;
using BrainGym.Application.Calls.Factors.Commands.Put;
using BrainGym.Application.Calls.Factors.Queries.Get;
using BrainGym.Application.Calls.Factors.Queries.GetAll;
using MediatR;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrainGym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FactorsController(IMediator mediatr)
        {
            this._mediator = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetAllFactorsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetFactorQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostFactorCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PutFactorCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteFactorCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
