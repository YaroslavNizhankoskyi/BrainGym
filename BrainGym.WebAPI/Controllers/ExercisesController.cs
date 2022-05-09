using BrainGym.Application.Calls.Exercises.Commands.Delete;
using BrainGym.Application.Calls.Exercises.Commands.FileUpload;
using BrainGym.Application.Calls.Exercises.Commands.Post;
using BrainGym.Application.Calls.Exercises.Queries.Get;
using BrainGym.Application.Calls.Exercises.Queries.GetAll;
using BrainGym.Domain;
using LightQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        [LightQuery(forcePagination: true, defaultPageSize: 5, defaultSort: "ExerciseType asc")]
        [ProducesResponseType(typeof(IEnumerable<Exercise>), 200)]
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

        [HttpPost("{id}/gamedata")]
        public async Task<IActionResult> UploadGameData(Guid id, IFormFile file)
        {
            if(file != null)
            {
                long length = file.Length;
                
                if (length <= 0)
                    return BadRequest();

                using var fileStream = file.OpenReadStream();

                byte[] bytes = new byte[length];

                fileStream.Read(bytes, 0, (int)file.Length);

                var result = await _mediator.Send(new ExerciseFileUploadCommand(id, bytes));

                if (result)
                {
                    return Ok();
                }

                return BadRequest();
            }

            return BadRequest("File not found");
        }
    }
}
