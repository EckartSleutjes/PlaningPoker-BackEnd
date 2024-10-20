namespace PlaningPoker.Domain.Entity
{
    public class Room : Entity
    {
        private Room() { }
        public Room(string name, Guid createdBy, string? description = null, string? password = null)
        {
            Tag = Guid.NewGuid().ToString().Split('-')[0];
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

        public void SetPokerItems(List<string> pokerItems)
        {
            PokerItems = string.Join(',', pokerItems);
        }
    }
}
