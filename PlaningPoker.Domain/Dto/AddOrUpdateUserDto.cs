using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PlaningPoker.Domain.Dto
{
    public record AddOrUpdateUserDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Username { get; set; } = null!;
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;
        [PasswordPropertyText]
        [Required]
        public string Password { get; set; } = null!;
    }
}
