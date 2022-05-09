using BrainGym.Application.Calls.User.Queries.FactorRecommendation;
using BrainGym.Application.Calls.User.Queries.ScoreRecommendation;
using BrainGym.WebAPI.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrainGym.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("exercise/{id}")]
        public async Task<IActionResult> GetFactorRecommendation(Guid id)
        {
            var evaluation = await _mediator.Send(new GetFactorRecommendationRequest(id));

            if (evaluation.HasErrors)
            {
                return BadRequest(evaluation.Errors);
            }

            var result = new FactorRecommendationDto(evaluation.Recommendation, evaluation.FactorType);

            return Ok(result);
        }

        [HttpGet("score/{id}")]
        public async Task<IActionResult> GetScoreRecomemndation(Guid id)
        {
            var result = await _mediator.Send(new ScoreRecommendationRequest(id));
            return Ok(result);
        }
    }
}
