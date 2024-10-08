using PlaningPoker.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlaningPoker.Domain.Dto
{
    public record StorieDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(1)]
        public string Description { get; set; }
        [Required]
        public Guid RoomId { get; set; }

        public static explicit operator Storie(StorieDto dto)
        {
            return new Storie(dto.Description, dto.RoomId);
        }
    }
}
