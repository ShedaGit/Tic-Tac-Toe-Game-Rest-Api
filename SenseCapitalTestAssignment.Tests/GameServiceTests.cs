using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using SenseCapitalTestAssignment.Data;
using SenseCapitalTestAssignment.Models;
using SenseCapitalTestAssignment.Services;

namespace SenseCapitalTestAssignment.Tests
{
    [TestFixture]
    public class GameServiceTests
    {
        private Mock<GameContext> _mockContext;
        private IGameService _gameService;
        private IQueryable<Game> _games;

        [SetUp]
        public void Setup()
        {
            _games = new List<Game>
            {
                new Game { Id = "1", Board = "         ", NextPlayer = "X", Winner = null, IsDraw = false, IsGameOver = false },
                new Game { Id = "2", Board = " X       ", NextPlayer = "O", Winner = null, IsDraw = false, IsGameOver = false },
                new Game { Id = "3", Board = "XXXOO    ", NextPlayer = "X", Winner = "X", IsDraw = false, IsGameOver = true },
                new Game { Id = "4", Board = "XOXOXXOXO", NextPlayer = "X", Winner = null, IsDraw = true, IsGameOver = true },
                new Game { Id = "5", Board = "XO OXO  ", NextPlayer = "X", Winner = null, IsDraw = false, IsGameOver = false },
                new Game { Id = "6", Board = "XO  X   ", NextPlayer = "O", Winner = null, IsDraw = false, IsGameOver = false },
                new Game { Id = "7", Board = "XO OXXO ", NextPlayer = "O", Winner = "X", IsDraw = false, IsGameOver = true }
            }.AsQueryable();

            var mockSet = _games.BuildMockDbSet();

            _mockContext = new Mock<GameContext>(new DbContextOptions<GameContext>());
            _mockContext.Setup(c => c.Games).Returns(mockSet.Object);

            _gameService = new GameService(_mockContext.Object);
        }

        [Test]
        public async Task GetGamesAsync_ReturnsAllGames()
        {
            // Arrange

            // Act
            var actual = await _gameService.GetGamesAsync();

            // Assert
            Assert.IsNotNull(actual);
            Assert.That(actual.Count(), Is.EqualTo(7));
            CollectionAssert.AreEqual(actual, _games);
        }
    }
}
