using PlaningPoker.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlaningPoker.Domain.Dto
{
    public record StoriePlayerDto
    {
        [Required]
        public Guid PlayerId { get; set; }
        [Required]
        public Guid StorieId { get; set; }
        [Required]
        public string PokerItemSelected { get; set; } = null!;

        public static explicit operator StoriePlayer(StoriePlayerDto dto)
        {
            return new StoriePlayer(dto.PlayerId, dto.StorieId, dto.PokerItemSelected);
        }
    }
}
