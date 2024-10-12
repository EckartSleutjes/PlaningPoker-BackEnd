namespace PlaningPoker.Domain.Entity
{
    public class Poker : Entity
    {
        private Poker() { }

        public Poker(string description, Guid createdBy)
        {
            Description = description;
            CreatedBy = createdBy;
        }

        public string Description { get; private set; }
        public ICollection<PokerItem> PokerItems { get; private set; }

        public void SetPokerItem(List<PokerItem> pokerItems)
        {
            PokerItems = pokerItems;
        }
    }
}
