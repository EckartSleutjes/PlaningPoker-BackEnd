namespace PlaningPoker.Domain.Entity
{
    public class Room : Entity
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Password { get; set; } 
    }
}
