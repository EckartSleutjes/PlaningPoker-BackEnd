namespace PlaningPoker.Domain.Entity
{
    public class Storie : Entity
    {
        public Storie(Guid roomId, Guid createdBy)
        {
            Played = false;
            RoomId = roomId;
            CreatedBy = createdBy;
        }

        public bool Played { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
