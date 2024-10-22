using Moq;
using PlaningPoker.Application.Contract;
using PlaningPoker.Application.Service;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Tests
{
    public class PokerServiceTests
    {
        [Fact]
        public async Task CreatePoker_ShouldReturnTrue_WhenPokerIsCreatedSuccessfully()
        {
            // Arrange
            var pokerDto = new PokerDto { Description = "Test", UserId = Guid.NewGuid(), PokerItems = ["1"] };

            var pokerRepositoryMock = new Mock<IPokerRepository>();
            pokerRepositoryMock.Setup(p => p.CreatePoker(It.IsAny<Poker>())).Returns(Task.CompletedTask);

            var pokerService = new PokerService(pokerRepositoryMock.Object);

            // Act
            var result = await pokerService.CreatePoker(pokerDto);

            // Assert
            Assert.True(result);
        }


        [Fact]
        public async Task CreatePoker_ShouldReturnFalse_WhenExceptionIsThrown()
        {
            // Arrange
            var pokerDto = new PokerDto { Description = "Test", UserId = Guid.NewGuid(), PokerItems = ["1"] };

            var pokerRepositoryMock = new Mock<IPokerRepository>();
            pokerRepositoryMock.Setup(p => p.CreatePoker(It.IsAny<Poker>())).Throws(new Exception("Database failure"));

            var pokerService = new PokerService(pokerRepositoryMock.Object);

            // Act
            var result = await pokerService.CreatePoker(pokerDto);

            // Assert
            Assert.False(result);
        }


        [Fact]
        public async Task GetPokerItemsByPokerId_ShouldReturnPokerItems_WhenItemsExist()
        {
            // Arrange
            var pokerId = Guid.NewGuid();
            var pokerItems = new List<PokerItem>
            {
                new PokerItem ("1", pokerId, pokerId),
                new PokerItem ("2", pokerId, pokerId)
            };

            var pokerRepositoryMock = new Mock<IPokerRepository>();
            pokerRepositoryMock.Setup(p => p.GetPokerItemsByPokerId(pokerId)).ReturnsAsync(pokerItems);

            var pokerService = new PokerService(pokerRepositoryMock.Object);

            // Act
            var result = await pokerService.GetPokerItemsByPokerId(pokerId);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("1", result[0].Description);
            Assert.Equal("2", result[1].Description);
        }

        [Fact]
        public async Task GetPokerItemsByPokerId_ShouldReturnEmptyList_WhenNoItemsExist()
        {
            // Arrange
            var pokerId = Guid.NewGuid();
            var pokerItems = new List<PokerItem>();

            var pokerRepositoryMock = new Mock<IPokerRepository>();
            pokerRepositoryMock.Setup(p => p.GetPokerItemsByPokerId(pokerId)).ReturnsAsync(pokerItems);

            var pokerService = new PokerService(pokerRepositoryMock.Object);

            // Act
            var result = await pokerService.GetPokerItemsByPokerId(pokerId);

            // Assert
            Assert.Empty(result);
        }

    }
}
