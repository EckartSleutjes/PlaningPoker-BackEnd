using System.Diagnostics.CodeAnalysis;

namespace PlaningPoker.Domain.Entity
{
    public class Player : Entity
    {
        public Player(string name, string email, Guid roomId, Guid createdBy)
        {
            Name = name;
            Email = email;
            RoomId = roomId;
            CreatedBy = createdBy;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
