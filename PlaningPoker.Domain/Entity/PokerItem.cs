using System.Text.Json.Serialization;

namespace PlaningPoker.Domain.Entity
{
    public class PokerItem : Entity
    {
        private PokerItem() { }
        public PokerItem(string description, Guid pokerId, Guid createdBy)
        {
            Description = description;
            PokerId = pokerId;
            CreatedBy = createdBy;
        }

        public string Description { get; private set; }
        public Guid PokerId { get; private set; }
        [JsonIgnore]
        public Poker Poker { get; private set; }
    }
}
