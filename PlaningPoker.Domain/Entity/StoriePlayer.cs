namespace PlaningPoker.Domain.Entity
{
    public class StoriePlayer : Entity
    {
        private StoriePlayer() { }
        public StoriePlayer(Guid playerId, Guid storieId, Guid createdBy)
        {
            PlayerId = playerId;
            StorieId = storieId;
            CreatedBy = createdBy;
            Flip = false;
        }

        public Guid PlayerId { get; private set; }
        public Player Player { get; private set; }

        public Guid StorieId { get; private set; }
        public Storie Storie { get; private set; }

        public Guid? PokerItemId { get; private set; }
        public PokerItem PokerItem { get; private set; }

        public bool Flip { get; private set; }

        public void SetPokerItemId(Guid pokerItemId)
        {
            PokerItemId = pokerItemId;
        }
    }
}
