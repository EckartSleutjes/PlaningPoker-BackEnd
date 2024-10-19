using System.Text.Json.Serialization;

namespace PlaningPoker.Domain.Entity
{
    public class Player : Entity
    {
        private Player() { }
        public Player(string name, string email, Guid? roomId = null, Guid? createdBy = null)
        {
            Name = name;
            Email = email;
            RoomId = roomId ?? Guid.Empty;
            CreatedBy = createdBy;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Guid RoomId { get; private set; }
        [JsonIgnore]
        public Room Room { get; private set; }
        public ICollection<StoriePlayer> StoriePlayers { get; private set; }

        public void SetRoomId (Guid roomId)
        {
            RoomId = roomId;    
        }
    }
}
