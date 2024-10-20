using PlaningPoker.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlaningPoker.Domain.Dto
{
    public record StorieDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Description { get; set; } = null!;
        [Required]
        public string TagRoom { get; set; } = string.Empty;

        public static explicit operator Storie(StorieDto dto)
        {
            return new Storie(dto.Description);
        }
    }
}
