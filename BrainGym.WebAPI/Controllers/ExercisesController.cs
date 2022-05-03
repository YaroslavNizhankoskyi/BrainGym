using BrainGym.Application.Calls.Exercises.Commands.Delete;
using BrainGym.Application.Calls.Exercises.Commands.Post;
using BrainGym.Application.Calls.Exercises.Queries.Get;
using BrainGym.Application.Calls.Exercises.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrainGym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExercisesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllExercisesQuery());

            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetExerciseQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostExerciseCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteExerciseCommand(id));

            return Ok(result);
        }
    }
}
