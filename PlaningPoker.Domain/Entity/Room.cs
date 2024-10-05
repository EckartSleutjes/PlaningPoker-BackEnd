using PlaningPoker.Domain.Dto;

namespace PlaningPoker.Domain.Entity
{
    public class Room : Entity
    {
        private Room() { }
        public Room(string tag, string name, Guid createdBy, string? description = null, string? password = null)
        {
            Tag = tag;
            Name = name;
            Description = description;
            Password = password;
            CreatedBy = createdBy;
        }
        public string Tag { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Password { get; set; }
    }
}
