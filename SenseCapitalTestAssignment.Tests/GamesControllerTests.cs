using Microsoft.AspNetCore.Mvc;
using Moq;
using SenseCapitalTestAssignment.Controllers;
using SenseCapitalTestAssignment.Models;
using SenseCapitalTestAssignment.Services;

namespace SenseCapitalTestAssignment.Tests
{
    public class GamesControllerTests
    {
        private readonly Mock<IGameService> _mockGameService;
        private readonly GamesController _controller;

        public GamesControllerTests()
        {
            _mockGameService = new Mock<IGameService>();
            _controller = new GamesController(_mockGameService.Object);
        }

        [Fact]
        public async Task GetGamesAsync_ShouldReturnOkResult_WithListOfGames()
        {
            // Arrange
            var games = new List<Game>
            {
                new Game { Id = "1", Board = "         ", NextPlayer = "X", Winner = null, IsDraw = false, IsGameOver = false },
                new Game { Id = "2", Board = " X       ", NextPlayer = "O", Winner = null, IsDraw = false, IsGameOver = false },
                new Game { Id = "3", Board = "XXXOO    ", NextPlayer = "X", Winner = "X", IsDraw = false, IsGameOver = true },
                new Game { Id = "4", Board = "XOXOXXOXO", NextPlayer = "X", Winner = null, IsDraw = true, IsGameOver = true },
            };
            _mockGameService.Setup(x => x.GetGamesAsync()).ReturnsAsync(games);

            // Act
            var actual = await _controller.GetGamesAsync();

            // Assert
            var expectedResult = Assert.IsType<OkObjectResult>(actual.Result);
            var expectedCount = Assert.IsAssignableFrom<IEnumerable<Game>>(expectedResult.Value);
            Assert.Equal(4, expectedCount.Count());
        }


    }
}
