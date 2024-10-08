using System.Text.Json.Serialization;

namespace PlaningPoker.Domain.Entity
{
    public class StoriePlayer : Entity
    {
        private StoriePlayer() { }
        public StoriePlayer(Guid playerId, Guid storieId, string pokerItem, Guid? createdBy = null)
        {
            PlayerId = playerId;
            StorieId = storieId;
            PokerItem = pokerItem;
            CreatedBy = createdBy ?? playerId;
            Flip = false;
        }
        public Guid PlayerId { get; private set; }
        [JsonIgnore]
        public Player Player { get; private set; }
        public Guid StorieId { get; private set; }
        [JsonIgnore]
        public Storie Storie { get; private set; }
        public string PokerItem { get; private set; }
        public bool Flip { get; private set; }
    }
}
