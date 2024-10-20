using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.API.Hubs
{
    public class RoomHub(IStoriePlayerService _storiePlayerService, IStorieService _storieService, IPlayerService _playerService, IRoomService _roomService) : Hub<IRoomClient>
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            Console.WriteLine(Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }
        public async Task EmitCardUpdated(Guid storieId)
        {
            var storie = await _storieService.GetStorieById(storieId);
            if (storie == null)
                return;
            var players = _playerService.GetPlayersByRoomId(storie.RoomId);
            await Clients.All.PendingCardsUpdated(players);
        }
        public async Task EmitCardUpdated2(string tagRoom)
        {
            var room = await _roomService.GetRoomByTag(tagRoom);
            if (room == null)
                return;
            var players = _playerService.GetPlayersByRoomId(room.Id);
            await Clients.All.PendingCardsUpdated(players);
        }
        public async Task CreateStoriePlayer(StoriePlayerDto dto)
        {
            await _storiePlayerService.CreateStoriePlayer(dto);
            await EmitCardUpdated(dto.StorieId);
        }
        public async Task CreatePlayer(PlayerDto dto)
        {
            await _playerService.CreatePlayer(dto);
            await EmitCardUpdated2(dto.TagRoom);
        }

        public async Task CreateStorie(StorieDto dto)
        {
            await _storieService.CreateStorie(dto);
            await EmitCardUpdated2(dto.TagRoom);
        }
    }
    public interface IRoomClient
    {
        [AllowAnonymous]
        Task PendingCardsUpdated(IEnumerable<PlayerListDto> cards);
    }
}
