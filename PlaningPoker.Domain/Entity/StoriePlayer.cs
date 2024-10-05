namespace PlaningPoker.Domain.Entity
{
    public class StoriePlayer : Entity
    {
        public StoriePlayer(Guid playerId, Guid storieId, Guid createdBy)
        {
            PlayerId = playerId;
            StorieId = storieId;
            CreatedBy = createdBy;
            Flip = false;
        }

        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        public Guid StorieId { get; set; }
        public Storie Storie { get; set; }

        public Guid? PokerItemId { get; set; }
        //public PokerItem PokerItem { get; set; }

        public bool Flip { get; set; }

        public void SetPokerItemId(Guid pokerItemId)
        {
            PokerItemId = pokerItemId;
        }
    }
}
