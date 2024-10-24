using Moq;
using PlaningPoker.Application.Contract;
using PlaningPoker.Application.Service;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Tests
{
    public class StorieServiceTests
    {
        [Fact]
        public async Task CreateStorie_ShouldReturnFalse_WhenRoomIsNotFound()
        {
            // Arrange
            var storieDto = new StorieDto { TagRoom = "InvalidRoomTag" };

            var roomServiceMock = new Mock<IRoomService>();
            roomServiceMock.Setup(r => r.GetRoomByTag(storieDto.TagRoom)).ReturnsAsync((Room?)null);

            var storieRepositoryMock = new Mock<IStorieRepository>();

            var storieService = new StorieService(storieRepositoryMock.Object, roomServiceMock.Object);

            // Act
            var result = await storieService.CreateStorie(storieDto);

            // Assert
            Assert.False(result);
            storieRepositoryMock.Verify(s => s.CreateStorie(It.IsAny<Storie>()), Times.Never);
        }

        [Fact]
        public async Task CreateStorie_ShouldReturnFalse_WhenRoomHasStorieNotPlayed()
        {
            // Arrange
            var storieDto = new StorieDto { TagRoom = "RoomTag" };
            var room = new Room("RoomTest");

            var roomServiceMock = new Mock<IRoomService>();
            roomServiceMock.Setup(r => r.GetRoomByTag(storieDto.TagRoom)).ReturnsAsync(room);

            var storieServiceMock = new Mock<IStorieRepository>();
            storieServiceMock.Setup(s => s.GetStoriesByRoomId(room.Id, false))
                             .ReturnsAsync([new ("StorieTest")]);

            var storieService = new StorieService(storieServiceMock.Object, roomServiceMock.Object);

            // Act
            var result = await storieService.CreateStorie(storieDto);

            // Assert
            Assert.False(result);
            storieServiceMock.Verify(s => s.CreateStorie(It.IsAny<Storie>()), Times.Never);
        }

        [Fact]
        public async Task CreateStorie_ShouldReturnFalse_WhenExceptionIsThrown()
        {
            // Arrange
            var storieDto = new StorieDto { TagRoom = "RoomTag" };

            var roomServiceMock = new Mock<IRoomService>();
            roomServiceMock.Setup(r => r.GetRoomByTag(storieDto.TagRoom)).ThrowsAsync(new Exception("Test exception"));

            var storieRepositoryMock = new Mock<IStorieRepository>();

            var storieService = new StorieService(storieRepositoryMock.Object, roomServiceMock.Object);

            // Act
            var result = await storieService.CreateStorie(storieDto);

            // Assert
            Assert.False(result);
            storieRepositoryMock.Verify(s => s.CreateStorie(It.IsAny<Storie>()), Times.Never);
        }

        [Fact]
        public async Task GetStorieById_ShouldReturnStorie_WhenStorieExists()
        {
            // Arrange
            var storie = new Storie("StorieTest");
            var storieId = storie.Id;

            var storieRepositoryMock = new Mock<IStorieRepository>();
            storieRepositoryMock.Setup(s => s.GetStorieById(storieId)).ReturnsAsync(storie);

            var storieService = new StorieService(storieRepositoryMock.Object, null!);

            // Act
            var result = await storieService.GetStorieById(storieId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(storieId, result?.Id);
        }

        [Fact]
        public async Task GetStorieById_ShouldReturnNull_WhenStorieDoesNotExist()
        {
            // Arrange
            var storieId = Guid.NewGuid();

            var storieRepositoryMock = new Mock<IStorieRepository>();
            storieRepositoryMock.Setup(s => s.GetStorieById(storieId)).ReturnsAsync((Storie?)null);

            var storieService = new StorieService(storieRepositoryMock.Object, null!);

            // Act
            var result = await storieService.GetStorieById(storieId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetStoriesByRoomId_ShouldReturnStories_WhenStoriesExist()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var stories = new List<Storie> { new ("StorieTest"), new("StorieTest2") };

            var storieRepositoryMock = new Mock<IStorieRepository>();
            storieRepositoryMock.Setup(s => s.GetStoriesByRoomId(roomId, null)).ReturnsAsync(stories);

            var storieService = new StorieService(storieRepositoryMock.Object, null!);

            // Act
            var result = await storieService.GetStoriesByRoomId(roomId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetStoriesByRoomId_ShouldReturnEmptyList_WhenNoStoriesExist()
        {
            // Arrange
            var roomId = Guid.NewGuid();

            var storieRepositoryMock = new Mock<IStorieRepository>();
            storieRepositoryMock.Setup(s => s.GetStoriesByRoomId(roomId, null)).ReturnsAsync([]);

            var storieService = new StorieService(storieRepositoryMock.Object, null!);

            // Act
            var result = await storieService.GetStoriesByRoomId(roomId);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task PlayedStorie_ShouldMarkStorieAsPlayedSuccessfully()
        {
            // Arrange
            var storieId = Guid.NewGuid();

            var storieRepositoryMock = new Mock<IStorieRepository>();
            storieRepositoryMock.Setup(s => s.PlayedStorie(storieId)).Returns(Task.CompletedTask);

            var storieService = new StorieService(storieRepositoryMock.Object, null!);

            // Act
            await storieService.PlayedStorie(storieId);

            // Assert
            storieRepositoryMock.Verify(s => s.PlayedStorie(storieId), Times.Once);
        }

        [Fact]
        public async Task PlayedStorie_ShouldThrowException_WhenErrorOccurs()
        {
            // Arrange
            var storieId = Guid.NewGuid();

            var storieRepositoryMock = new Mock<IStorieRepository>();
            storieRepositoryMock.Setup(s => s.PlayedStorie(storieId)).ThrowsAsync(new Exception("Test exception"));

            var storieService = new StorieService(storieRepositoryMock.Object, null!);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => storieService.PlayedStorie(storieId));
        }

        [Fact]
        public async Task RoomHasStorieNotPlayed_ShouldReturnTrue_WhenUnplayedStoriesExist()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var storie = new Storie("StorieTest");
            var unplayedStories = new List<Storie> { storie };

            var storieRepositoryMock = new Mock<IStorieRepository>();
            storieRepositoryMock.Setup(s => s.GetStoriesByRoomId(roomId, false)).ReturnsAsync(unplayedStories);

            var storieService = new StorieService(storieRepositoryMock.Object, null!);

            // Act
            var result = await storieService.RoomHasStorieNotPlayed(roomId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task RoomHasStorieNotPlayed_ShouldReturnFalse_WhenNoUnplayedStoriesExist()
        {
            // Arrange
            var roomId = Guid.NewGuid();
            var unplayedStories = new List<Storie>();

            var storieRepositoryMock = new Mock<IStorieRepository>();
            storieRepositoryMock.Setup(s => s.GetStoriesByRoomId(roomId, false)).ReturnsAsync(unplayedStories);

            var storieService = new StorieService(storieRepositoryMock.Object, null!);

            // Act
            var result = await storieService.RoomHasStorieNotPlayed(roomId);

            // Assert
            Assert.False(result);
        }
    }
}
