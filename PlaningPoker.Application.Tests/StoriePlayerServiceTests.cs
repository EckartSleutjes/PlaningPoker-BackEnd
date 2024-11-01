using Moq;
using PlaningPoker.Application.Contract;
using PlaningPoker.Application.Service;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Tests
{
    public class StoriePlayerServiceTests
    {
        [Fact]
        public async Task CreateStoriePlayer_ShouldReturnTrue_WhenStoriePlayerIsCreatedSuccessfully()
        {
            // Arrange
            var storiePlayerDto = new StoriePlayerDto { PlayerId = Guid.NewGuid(), PokerItemSelected = "Item 1", StorieId = Guid.NewGuid() };
            var room = new Room ("RoomTest");
            room.SetPokerItems(["Item 1,Item 2"]);
            var players = new List<PlayerListDto> { new() { Name = "PlayerTest" , CurrentStoriePlayed = true, CurrentStorieId = storiePlayerDto.StorieId, PokerItemSelected = "Item 1" } };

            var roomServiceMock = new Mock<IRoomService>();
            roomServiceMock.Setup(r => r.GetRoomByPlayerId(storiePlayerDto.PlayerId)).ReturnsAsync(room);

            var storiePlayerRepositoryMock = new Mock<IStoriePlayerRepository>();
            var playerServiceMock = new Mock<IPlayerService>();
            playerServiceMock.Setup(p => p.GetPlayersByRoomId(room.Id)).Returns(players);

            var storieServiceMock = new Mock<IStorieService>();

            var storiePlayerService = new StoriePlayerService(storiePlayerRepositoryMock.Object, roomServiceMock.Object, playerServiceMock.Object, storieServiceMock.Object);

            // Act
            var result = await storiePlayerService.CreateStoriePlayer(storiePlayerDto);

            // Assert
            Assert.True(result);
            storiePlayerRepositoryMock.Verify(s => s.CreateStoriePlayer(It.IsAny<StoriePlayer>()), Times.Once);
            storieServiceMock.Verify(s => s.PlayedStorie(storiePlayerDto.StorieId), Times.Once);
        }

        [Fact]
        public async Task CreateStoriePlayer_ShouldReturnFalse_WhenPlayerIsNotInRoom()
        {
            // Arrange
            var storiePlayerDto = new StoriePlayerDto { PlayerId = Guid.NewGuid() };

            var roomServiceMock = new Mock<IRoomService>();
            roomServiceMock.Setup(r => r.GetRoomByPlayerId(storiePlayerDto.PlayerId)).ReturnsAsync((Room?)null);

            var storiePlayerRepositoryMock = new Mock<IStoriePlayerRepository>();
            var playerServiceMock = new Mock<IPlayerService>();
            var storieServiceMock = new Mock<IStorieService>();

            var storiePlayerService = new StoriePlayerService(storiePlayerRepositoryMock.Object, roomServiceMock.Object, playerServiceMock.Object, storieServiceMock.Object);

            // Act
            var result = await storiePlayerService.CreateStoriePlayer(storiePlayerDto);

            // Assert
            Assert.False(result);
            storiePlayerRepositoryMock.Verify(s => s.CreateStoriePlayer(It.IsAny<StoriePlayer>()), Times.Never);
        }

        [Fact]
        public async Task CreateStoriePlayer_ShouldReturnFalse_WhenPokerItemIsNotAllowed()
        {
            // Arrange
            var storiePlayerDto = new StoriePlayerDto { PlayerId = Guid.NewGuid(), PokerItemSelected = "Item 3" };
            var room = new Room ("RoomTest");
            room.SetPokerItems(["Item 1,Item 2"]);

            var roomServiceMock = new Mock<IRoomService>();
            roomServiceMock.Setup(r => r.GetRoomByPlayerId(storiePlayerDto.PlayerId)).ReturnsAsync(room);

            var storiePlayerRepositoryMock = new Mock<IStoriePlayerRepository>();
            var playerServiceMock = new Mock<IPlayerService>();
            var storieServiceMock = new Mock<IStorieService>();

            var storiePlayerService = new StoriePlayerService(storiePlayerRepositoryMock.Object, roomServiceMock.Object, playerServiceMock.Object, storieServiceMock.Object);

            // Act
            var result = await storiePlayerService.CreateStoriePlayer(storiePlayerDto);

            // Assert
            Assert.False(result);
            storiePlayerRepositoryMock.Verify(s => s.CreateStoriePlayer(It.IsAny<StoriePlayer>()), Times.Never);
        }

        [Fact]
        public async Task CreateStoriePlayer_ShouldReturnFalse_WhenExceptionIsThrown()
        {
            // Arrange
            var storiePlayerDto = new StoriePlayerDto { PlayerId = Guid.NewGuid(), PokerItemSelected = "Item 1" };

            var roomServiceMock = new Mock<IRoomService>();
            roomServiceMock.Setup(r => r.GetRoomByPlayerId(storiePlayerDto.PlayerId)).ThrowsAsync(new Exception("Test exception"));

            var storiePlayerRepositoryMock = new Mock<IStoriePlayerRepository>();
            var playerServiceMock = new Mock<IPlayerService>();
            var storieServiceMock = new Mock<IStorieService>();

            var storiePlayerService = new StoriePlayerService(storiePlayerRepositoryMock.Object, roomServiceMock.Object, playerServiceMock.Object, storieServiceMock.Object);

            // Act
            var result = await storiePlayerService.CreateStoriePlayer(storiePlayerDto);

            // Assert
            Assert.False(result);
            storiePlayerRepositoryMock.Verify(s => s.CreateStoriePlayer(It.IsAny<StoriePlayer>()), Times.Never);
        }

        [Fact]
        public async Task GetStoriePlayersByStorie_ShouldReturnStoriePlayers_WhenPlayersExistForStorie()
        {
            // Arrange
            var storieId = Guid.NewGuid();
            var storiePlayers = new List<StoriePlayer> { new(Guid.NewGuid(), storieId, "1"), new(Guid.NewGuid(), storieId, "1") };

            var storiePlayerRepositoryMock = new Mock<IStoriePlayerRepository>();
            storiePlayerRepositoryMock.Setup(s => s.GetStoriePlayersByStorie(storieId)).ReturnsAsync(storiePlayers);

            var storiePlayerService = new StoriePlayerService(storiePlayerRepositoryMock.Object, null!, null!, null!);

            // Act
            var result = await storiePlayerService.GetStoriePlayersByStorie(storieId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetStoriePlayersByStorie_ShouldReturnEmptyList_WhenNoPlayersExistForStorie()
        {
            // Arrange
            var storieId = Guid.NewGuid();

            var storiePlayerRepositoryMock = new Mock<IStoriePlayerRepository>();
            storiePlayerRepositoryMock.Setup(s => s.GetStoriePlayersByStorie(storieId)).ReturnsAsync([]);

            var storiePlayerService = new StoriePlayerService(storiePlayerRepositoryMock.Object, null!, null!, null!);

            // Act
            var result = await storiePlayerService.GetStoriePlayersByStorie(storieId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task FlipCardInStorie_ShouldReturnTrue_WhenFlipCardIsSuccessful()
        {
            // Arrange
            var storiePlayerId = Guid.NewGuid();

            var storiePlayerRepositoryMock = new Mock<IStoriePlayerRepository>();
            storiePlayerRepositoryMock.Setup(s => s.FlipCardInStorie(storiePlayerId)).Returns(Task.CompletedTask);

            var storiePlayerService = new StoriePlayerService(storiePlayerRepositoryMock.Object, null!, null!, null!);

            // Act
            var result = await storiePlayerService.FlipCardInStorie(storiePlayerId);

            // Assert
            Assert.True(result);
            storiePlayerRepositoryMock.Verify(s => s.FlipCardInStorie(storiePlayerId), Times.Once);
        }

        [Fact]
        public async Task FlipCardInStorie_ShouldReturnFalse_WhenExceptionIsThrown()
        {
            // Arrange
            var storiePlayerId = Guid.NewGuid();

            var storiePlayerRepositoryMock = new Mock<IStoriePlayerRepository>();
            storiePlayerRepositoryMock.Setup(s => s.FlipCardInStorie(storiePlayerId)).ThrowsAsync(new Exception("Test exception"));

            var storiePlayerService = new StoriePlayerService(storiePlayerRepositoryMock.Object, null!, null!, null!);

            // Act
            var result = await storiePlayerService.FlipCardInStorie(storiePlayerId);

            // Assert
            Assert.False(result);
            storiePlayerRepositoryMock.Verify(s => s.FlipCardInStorie(storiePlayerId), Times.Once);
        }

    }
}
