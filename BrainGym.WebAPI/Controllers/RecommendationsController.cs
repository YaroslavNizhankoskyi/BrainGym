using BrainGym.Application.Calls.Recommendations.Commands.Delete;
using BrainGym.Application.Calls.Recommendations.Commands.Post;
using BrainGym.Application.Calls.Recommendations.Commands.Put;
using BrainGym.Application.Calls.Recommendations.Queries.GetAll;
using BrainGym.Domain;
using LightQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrainGym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecommendationsController(IMediator mediatr)
        {
            this._mediator = mediatr;
        }

        [LightQuery]
        [ProducesResponseType(typeof(IEnumerable<Recommendation>), 200)]
        [HttpGet]
        public async Task<IActionResult> Get(GetAllRecommendationsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostRecommedationCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PutRecommendationCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRecommendationCommand command)
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
