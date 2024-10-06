﻿using System.Text.Json.Serialization;

namespace PlaningPoker.Domain.Entity
{
    public class Storie : Entity
    {
        private Storie() { }
        public Storie(Guid roomId, Guid createdBy)
        {
            Played = false;
            RoomId = roomId;
            CreatedBy = createdBy;
        }

        public bool Played { get; private set; }
        public Guid RoomId { get; private set; }
        [JsonIgnore]
        public Room Room { get; private set; }
    }
}
