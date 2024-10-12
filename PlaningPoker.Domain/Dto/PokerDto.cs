using PlaningPoker.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace PlaningPoker.Domain.Dto
{
    public record PokerDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public List<string> PokerItems { get; set; } = [];
        public Guid UserId { get; set; }

        public static explicit operator Poker (PokerDto dto)
        {
            var pokerItems = new List<PokerItem> ();
            var poker = new Poker(dto.Description, dto.UserId);
            dto.PokerItems.ForEach(t => pokerItems.Add(new PokerItem(t, poker.Id, dto.UserId)));
            poker.SetPokerItem(pokerItems);
            return poker;
        }
    }
}
