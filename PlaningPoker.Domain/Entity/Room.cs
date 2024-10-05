using System.ComponentModel.DataAnnotations;

namespace PlaningPoker.Domain.Entity
{
    public class Room
    {
        public Room()
        {
            
        }

        [Key]
        public int RoomId { get; set; }

    }
}
