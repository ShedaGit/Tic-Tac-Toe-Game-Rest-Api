using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenseCapitalTestAssignment.Services;

namespace SenseCapitalTestAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesAsync()
        {
            var games = await _gameService.GetGamesAsync();
            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> CreateGameAsync()
        {
            var game = await _gameService.CreateGameAsync();
            return Ok(game);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameAsync(string id)
        {
            var game = await _gameService.GetGameAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }
    }
}
