using System.Text.Json.Serialization;

namespace PlaningPoker.Domain.Entity
{
    public class Storie : Entity
    {
        private Storie() { }
        public Storie(string description, Guid? createdBy = null)
        {
            Description = description;
            Played = false;
            CreatedBy = createdBy;
        }

        public string Description { get; private set; }
        public bool Played { get; private set; }
        public Guid RoomId { get; private set; }
        [JsonIgnore]
        public Room Room { get; private set; }

        public void SetRoomId(Guid roomId)
        {
            RoomId = roomId;
        }
    }
}
