using Moq;
using PlaningPoker.Application.Contract;
using PlaningPoker.Application.Service;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Tests
{
    public class PlayerServiceTests
    {
        [Fact]
        public async Task CreatePlayer_ShouldReturnPlayerId_WhenRoomExists()
        {
            // Arrange
            var room = new Room ("RoomTest");
            var playerDto = new PlayerDto { Name = "John", TagRoom = room.Tag };

            var roomRepositoryMock = new Mock<IRoomRepository>();
            var playerRepositoryMock = new Mock<IPlayerRepository>();

            roomRepositoryMock.Setup(r => r.GetRoomByTag(playerDto.TagRoom)).ReturnsAsync(room);
            playerRepositoryMock.Setup(p => p.CreatePlayer(It.IsAny<Player>())).Returns(Task.CompletedTask);

            var playerService = new PlayerService(playerRepositoryMock.Object, roomRepositoryMock.Object);

            // Act
            var result = await playerService.CreatePlayer(playerDto);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
            playerRepositoryMock.Verify(p => p.CreatePlayer(It.Is<Player>(p => p.Name == playerDto.Name)), Times.Once);
        }

        [Fact]
        public async Task CreatePlayer_ShouldReturnEmptyGuid_WhenRoomDoesNotExist()
        {
            // Arrange
            var playerDto = new PlayerDto { Name = "John", TagRoom = "non-existent-room" };

            var roomRepositoryMock = new Mock<IRoomRepository>();
            var playerRepositoryMock = new Mock<IPlayerRepository>();

            roomRepositoryMock.Setup(r => r.GetRoomByTag(playerDto.TagRoom)).ReturnsAsync((Room?)null);

            var playerService = new PlayerService(playerRepositoryMock.Object, roomRepositoryMock.Object);

            // Act
            var result = await playerService.CreatePlayer(playerDto);

            // Assert
            Assert.Equal(Guid.Empty, result);
            playerRepositoryMock.Verify(p => p.CreatePlayer(It.IsAny<Player>()), Times.Never);
        }

        [Fact]
        public async Task CreatePlayer_ShouldReturnEmptyGuid_WhenExceptionThrown()
        {
            // Arrange
            var playerDto = new PlayerDto { Name = "John", TagRoom = "room1" };

            var roomRepositoryMock = new Mock<IRoomRepository>();
            var playerRepositoryMock = new Mock<IPlayerRepository>();

            roomRepositoryMock.Setup(r => r.GetRoomByTag(playerDto.TagRoom)).Throws(new Exception("Database failure"));

            var playerService = new PlayerService(playerRepositoryMock.Object, roomRepositoryMock.Object);

            // Act
            var result = await playerService.CreatePlayer(playerDto);

            // Assert
            Assert.Equal(Guid.Empty, result);
        }

        [Fact]
        public async Task GetPlayerById_ShouldReturnPlayer_WhenPlayerExists()
        {
            // Arrange
            var player = new Player("John", "john@email.com");

            var playerRepositoryMock = new Mock<IPlayerRepository>();
            playerRepositoryMock.Setup(p => p.GetPlayerById(player.Id)).ReturnsAsync(player);

            var playerService = new PlayerService(playerRepositoryMock.Object, Mock.Of<IRoomRepository>());

            // Act
            var result = await playerService.GetPlayerById(player.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(player.Id, result.Id);
        }

        [Fact]
        public async Task GetPlayerById_ShouldReturnNull_WhenPlayerDoesNotExist()
        {
            // Arrange
            var playerId = Guid.NewGuid();

            var playerRepositoryMock = new Mock<IPlayerRepository>();
            playerRepositoryMock.Setup(p => p.GetPlayerById(playerId)).ReturnsAsync((Player?)null);

            var playerService = new PlayerService(playerRepositoryMock.Object, Mock.Of<IRoomRepository>());

            // Act
            var result = await playerService.GetPlayerById(playerId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetPlayersByRoomId_ShouldReturnEmptyList_WhenNoPlayersExist()
        {
            // Arrange
            var roomId = Guid.NewGuid();

            var playerRepositoryMock = new Mock<IPlayerRepository>();
            playerRepositoryMock.Setup(p => p.GetPlayersByRoomId(roomId)).ReturnsAsync([]);

            var playerService = new PlayerService(playerRepositoryMock.Object, Mock.Of<IRoomRepository>());

            // Act
            var result = playerService.GetPlayersByRoomId(roomId).ToList();

            // Assert
            Assert.Empty(result);
        }

    }
}