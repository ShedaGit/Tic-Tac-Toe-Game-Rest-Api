using Microsoft.AspNetCore.Mvc;
using Moq;
using SenseCapitalTestAssignment.Controllers;
using SenseCapitalTestAssignment.Models;
using SenseCapitalTestAssignment.Services;

namespace SenseCapitalTestAssignment.Tests
{
    [TestFixture]
    public class MovesControllerTests
    {
        private Mock<IGameService> _mockGameService;
        private MovesController _controller;

        [SetUp]
        public void Setup()
        {
            _mockGameService = new Mock<IGameService>();
            _controller = new MovesController(_mockGameService.Object);
        }

        [Test]
        public async Task MakeMoveAsync_ShouldReturnOkResult()
        {
            // Arrange
            _mockGameService.Setup(x => x.GetGameAsync(It.IsAny<string>())).ReturnsAsync(new Game());
            _mockGameService.Setup(x => x.MakeMoveAsync(It.IsAny<Game>(), It.IsAny<MoveRequest>())).ReturnsAsync(new Game());

            // Act
            var actual = await _controller.MakeMoveAsync(It.IsAny<string>(), It.IsAny<MoveRequest>());

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actual.Result);
            var okObjectResult = actual.Result as OkObjectResult;
            Assert.IsInstanceOf<Game>(okObjectResult?.Value);
        }
    }
}
