﻿using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IRoomRepository
    {
        Task CreateRoom(Room room);
        Task<Room?> GetRoomById(Guid roomId);
        Task<Room?> GetRoomByPlayerId(Guid playerId);
        Task<Room?> GetRoomByTag(string tag);
    }
}
