﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using SenseCapitalTestAssignment.Controllers;
using SenseCapitalTestAssignment.Models;
using SenseCapitalTestAssignment.Services;

namespace SenseCapitalTestAssignment.Tests
{
    public class GamesControllerTests
    {
        private Mock<IGameService> _mockGameService;
        private GamesController _controller;
        private List<Game> _games;

        [SetUp]
        public void Setup()
        {
            _mockGameService = new Mock<IGameService>();
            _controller = new GamesController(_mockGameService.Object);

            _games = new List<Game>
            {
                new Game { Id = "1", Board = "         ", NextPlayer = "X", Winner = null, IsDraw = false, IsGameOver = false },
                new Game { Id = "2", Board = " X       ", NextPlayer = "O", Winner = null, IsDraw = false, IsGameOver = false },
                new Game { Id = "3", Board = "XXXOO    ", NextPlayer = "X", Winner = "X", IsDraw = false, IsGameOver = true },
                new Game { Id = "4", Board = "XOXOXXOXO", NextPlayer = "X", Winner = null, IsDraw = true, IsGameOver = true },
            };
        }

        [Test]
        public async Task GetGamesAsync_ShouldReturnOkResult_WithListOfGames()
        {
            // Arrange
            _mockGameService.Setup(x => x.GetGamesAsync()).ReturnsAsync(_games);

            // Act
            var actual = await _controller.GetGamesAsync();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actual.Result);
            var okObjectResult = actual.Result as OkObjectResult;
            Assert.IsInstanceOf<IEnumerable<Game>>(okObjectResult?.Value);
            var gamesList = okObjectResult?.Value as IEnumerable<Game>;
            Assert.That(gamesList?.Count(), Is.EqualTo(4));
        }

        [Test]
        public async Task CreateGameAsync_ShouldReturnOkResult_WithNewGame()
        {
            // Arrange
            var newGame = new Game { Id = "5", Board = "         ", NextPlayer = "X", Winner = null, IsDraw = false, IsGameOver = false };
            _mockGameService.Setup(x => x.CreateGameAsync()).ReturnsAsync(newGame);

            // Act
            var actual = await _controller.CreateGameAsync();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actual.Result);
            var okObjectResult = actual.Result as OkObjectResult;
            Assert.IsInstanceOf<Game>(okObjectResult?.Value);
        }
    }
}
