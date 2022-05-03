using BrainGym.Application.Calls.Scores.Commands.Post;
using BrainGym.Application.Calls.Scores.Queries.Get;
using BrainGym.Application.Calls.Scores.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrainGym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScoresControllers(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetAllScoresQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetScoreQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostScoreCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
