using PlaningPoker.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlaningPoker.Domain.Dto
{
    public record RoomDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Name { get; set; } = null!;
        public Guid UserId { get; set; }
        public string? Description { get; set; }
        public string? Password { get; set; }
        public Guid? PokerId { get; set; }
        public List<string>? PokerItems { get; set; }

        public static explicit operator Room (RoomDto dto)
        {
            return new Room(dto.Name, dto.UserId, dto.Description, dto.Password);
        }
    }
}
