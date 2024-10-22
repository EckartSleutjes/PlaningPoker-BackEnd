using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PlaningPoker.Domain.Dto
{
    public record LoginDto
    {
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
