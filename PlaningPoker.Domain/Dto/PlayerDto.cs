using PlaningPoker.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlaningPoker.Domain.Dto
{
    public record PlayerDto
    {
        [Required]
        public string TagRoom { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public static implicit operator Player(PlayerDto dto)
        {
            return new Player(dto.Name, dto.Email);
        }
    }
}
