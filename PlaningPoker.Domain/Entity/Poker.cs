namespace PlaningPoker.Domain.Entity
{
    public class Poker : Entity
    {
        public Poker(string description, Guid createdBy)
        {
            Description = description;
            CreatedBy = createdBy;
        }

        public string Description { get; set; }
    }
}
