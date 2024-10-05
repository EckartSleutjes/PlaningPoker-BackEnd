using System.ComponentModel.DataAnnotations;

namespace PlaningPoker.Domain.Entity
{
    public class Entity
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public Guid? CreatedBy { get; protected set; }
    }
}
