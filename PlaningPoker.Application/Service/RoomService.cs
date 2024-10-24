using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Service
{
    public class RoomService (IRoomRepository _roomRepository, IPokerService _pokerService, IPlayerService _playerService, IAuthenticationService _authenticationService) : IRoomService
    {
        public async Task<CreateRoomResponseDto> CreateRoom(RoomDto room, Guid userId)
        {
            try
            {
                var roomModel = (Room)room;
                roomModel.SetUserId(userId);
                if (room.PokerId is null)
                {
                    if (room.PokerItems is null)
                        throw new Exception("Poker items empty");
                    roomModel.SetPokerItems(room.PokerItems);
                }
                else
                {
                    var pokerItems = await _pokerService.GetPokerItemsByPokerId((Guid)room.PokerId);
                    roomModel.SetPokerItems(pokerItems.Select(t => t.Description).ToList());
                }

                await _roomRepository.CreateRoom(roomModel);
                var user = await _authenticationService.FindAsync(userId);
                var playerId = await _playerService.CreatePlayer(new PlayerDto { Email = user.Email, Name = user.Username, TagRoom = roomModel.Tag });
                return new CreateRoomResponseDto { TagRoom = roomModel.Tag, PlayerId = playerId };
            }           
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateRoom => {ex}");
                return new CreateRoomResponseDto { PlayerId = Guid.Empty };
            }
        }
        public async Task<Room?> GetRoomById(Guid roomId)
        {
            return await _roomRepository.GetRoomById(roomId);
        }
        public async Task<Room?> GetRoomByPlayerId(Guid playerId)
        {
            return await _roomRepository.GetRoomByPlayerId(playerId);
        }
        public async Task<Room?> GetRoomByTag(string tag)
        {
            return await _roomRepository.GetRoomByTag(tag);
        }
    }
}
