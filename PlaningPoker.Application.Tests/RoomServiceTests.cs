using Moq;
using PlaningPoker.Application.Contract;
using PlaningPoker.Application.Service;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Tests
{
    public class RoomServiceTests
    {
        [Fact]
        public async Task CreateRoom_ShouldReturnCreateRoomResponseDto_WhenRoomIsCreatedWithPokerId()
        {
            // Arrange
            var roomDto = new RoomDto { PokerId = Guid.NewGuid() };
            var pokerItems = new List<PokerItem> { new("Item 1", (Guid)roomDto.PokerId, (Guid)roomDto.PokerId), new("Item 2", (Guid)roomDto.PokerId, (Guid)roomDto.PokerId) };

            var roomRepositoryMock = new Mock<IRoomRepository>();
            var playerServiceMock = new Mock<IPlayerService>();
            var pokerServiceMock = new Mock<IPokerService>();
            pokerServiceMock.Setup(p => p.GetPokerItemsByPokerId((Guid)roomDto.PokerId!)).ReturnsAsync(pokerItems);
            playerServiceMock.Setup(p => p.CreatePlayer(It.IsAny<PlayerDto>())).ReturnsAsync(Guid.NewGuid());

            var roomService = new RoomService(roomRepositoryMock.Object, pokerServiceMock.Object, playerServiceMock.Object);

            // Act
            var result = await roomService.CreateRoom(roomDto);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.PlayerId);
            roomRepositoryMock.Verify(r => r.CreateRoom(It.IsAny<Room>()), Times.Once);
        }

        [Fact]
        public async Task CreateRoom_ShouldThrowException_WhenPokerItemsAreEmpty()
        {
            // Arrange
            var roomDto = new RoomDto { PokerId = null, PokerItems = null }; // Itens de poker null

            var roomRepositoryMock = new Mock<IRoomRepository>();
            var playerServiceMock = new Mock<IPlayerService>();
            var pokerServiceMock = new Mock<IPokerService>();

            var roomService = new RoomService(roomRepositoryMock.Object, pokerServiceMock.Object, playerServiceMock.Object);

            // Act & Assert
            Assert.Equal(Guid.Empty, roomService.CreateRoom(roomDto).GetAwaiter().GetResult().PlayerId);
        }

        [Fact]
        public async Task CreateRoom_ShouldReturnCreateRoomResponseDto_WhenRoomIsCreatedWithoutPokerIdButWithPokerItems()
        {
            // Arrange
            var roomDto = new RoomDto { PokerItems = new List<string> { "Item 1", "Item 2" } };

            var roomRepositoryMock = new Mock<IRoomRepository>();
            var playerServiceMock = new Mock<IPlayerService>();
            playerServiceMock.Setup(p => p.CreatePlayer(It.IsAny<PlayerDto>())).ReturnsAsync(Guid.NewGuid());

            var pokerServiceMock = new Mock<IPokerService>();

            var roomService = new RoomService(roomRepositoryMock.Object, pokerServiceMock.Object, playerServiceMock.Object);

            // Act
            var result = await roomService.CreateRoom(roomDto);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.PlayerId);
            roomRepositoryMock.Verify(r => r.CreateRoom(It.IsAny<Room>()), Times.Once);
        }


        [Fact]
        public async Task GetRoomById_ShouldReturnRoom_WhenRoomExists()
        {
            // Arrange
            var room = new Room("RoomTest", Guid.NewGuid());

            var roomRepositoryMock = new Mock<IRoomRepository>();
            roomRepositoryMock.Setup(r => r.GetRoomById(room.Id)).ReturnsAsync(room);

            var roomService = new RoomService(roomRepositoryMock.Object, null!, null!);

            // Act
            var result = await roomService.GetRoomById(room.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(room.Id, result.Id);
        }


        [Fact]
        public async Task GetRoomById_ShouldReturnNull_WhenRoomDoesNotExist()
        {
            // Arrange
            var roomId = Guid.NewGuid();

            var roomRepositoryMock = new Mock<IRoomRepository>();
            roomRepositoryMock.Setup(r => r.GetRoomById(roomId)).ReturnsAsync((Room?)null);

            var roomService = new RoomService(roomRepositoryMock.Object, null!, null!);

            // Act
            var result = await roomService.GetRoomById(roomId);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task GetRoomByPlayerId_ShouldReturnRoom_WhenRoomExistsForPlayer()
        {
            // Arrange
            var playerId = Guid.NewGuid();
            var room = new Room("RoomTest", Guid.NewGuid());

            var roomRepositoryMock = new Mock<IRoomRepository>();
            roomRepositoryMock.Setup(r => r.GetRoomByPlayerId(playerId)).ReturnsAsync(room);

            var roomService = new RoomService(roomRepositoryMock.Object, null!, null!);

            // Act
            var result = await roomService.GetRoomByPlayerId(playerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(room.Id, result.Id);
        }


        [Fact]
        public async Task GetRoomByPlayerId_ShouldReturnNull_WhenRoomDoesNotExistForPlayer()
        {
            // Arrange
            var playerId = Guid.NewGuid();

            var roomRepositoryMock = new Mock<IRoomRepository>();
            roomRepositoryMock.Setup(r => r.GetRoomByPlayerId(playerId)).ReturnsAsync((Room?)null);

            var roomService = new RoomService(roomRepositoryMock.Object, null!, null!);

            // Act
            var result = await roomService.GetRoomByPlayerId(playerId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetRoomByTag_ShouldReturnRoom_WhenRoomExistsForTag()
        {
            // Arrange
            var room = new Room("RoomTest", Guid.NewGuid());

            var roomRepositoryMock = new Mock<IRoomRepository>();
            roomRepositoryMock.Setup(r => r.GetRoomByTag(room.Tag)).ReturnsAsync(room);

            var roomService = new RoomService(roomRepositoryMock.Object, null!, null!);

            // Act
            var result = await roomService.GetRoomByTag(room.Tag);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(room.Tag, result.Tag);
        }


        [Fact]
        public async Task GetRoomByTag_ShouldReturnNull_WhenRoomDoesNotExistForTag()
        {
            // Arrange
            var tag = "non-existent-room";

            var roomRepositoryMock = new Mock<IRoomRepository>();
            roomRepositoryMock.Setup(r => r.GetRoomByTag(tag)).ReturnsAsync((Room?)null);

            var roomService = new RoomService(roomRepositoryMock.Object, null!, null!);

            // Act
            var result = await roomService.GetRoomByTag(tag);

            // Assert
            Assert.Null(result);
        }

    }
}
