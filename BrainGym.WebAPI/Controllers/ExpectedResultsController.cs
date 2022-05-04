using BrainGym.Application.Calls.ExpectedResults.Commands.Delete;
using BrainGym.Application.Calls.ExpectedResults.Commands.Post;
using BrainGym.Application.Calls.ExpectedResults.Commands.Put;
using BrainGym.Application.Calls.ExpectedResults.Queries.Get;
using BrainGym.Application.Calls.ExpectedResults.Queries.GetAll;
using BrainGym.Domain;
using LightQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrainGym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpectedResultsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpectedResultsController(IMediator mediatr)
        {
            this._mediator = mediatr;
        }

        [LightQuery]
        [ProducesResponseType(typeof(IEnumerable<ExpectedResult>), 200)]
        [HttpGet]
        public async Task<IActionResult> Get(GetAllExpectedResultsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetExpectedResultQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostExpectedResultCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PutExpectedResultCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteExpectedResultCommand command)
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
