﻿using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Application.Contract
{
    public interface IPlayerService
    {
        Task<Player?> GetPlayerById (Guid playerId);
        IEnumerable<PlayerListDto> GetPlayersByRoomId(Guid roomId);
        Task<Guid> CreatePlayer (PlayerDto player);
    }
}
