using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenseCapitalTestAssignment.Services;

namespace SenseCapitalTestAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public MovesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Game?>> MakeMoveAsync(string id, [FromBody] MoveRequest moveRequest)
        {
            var game = await _gameService.GetGameAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            var updatedGame = await _gameService.MakeMoveAsync(game, moveRequest);

            if (updatedGame == null)
            {
                return BadRequest("Invalid move.");
            }

            return Ok(updatedGame);
        }
    }
}
