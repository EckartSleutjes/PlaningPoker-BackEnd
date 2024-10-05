using System.ComponentModel.DataAnnotations;

namespace PlaningPoker.Domain.Entity
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }
    }
}
