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
        public string Tag { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string? Password { get; private set; }
        public string PokerItems { get; private set; }

        public void SetPokerItems(List<PokerItem> pokerItems)
        {
            PokerItems = string.Join(',', pokerItems.Select(t => t.Description));
        }
    }
}
