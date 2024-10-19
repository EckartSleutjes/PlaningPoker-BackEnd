namespace PlaningPoker.Domain.Dto
{
    public record PlayerListDto
    {
        public string Name { get; set; } = string.Empty;
        public bool CurrentStoriePlayed { get; set; }
        public string? PokerItemSelected { get; set; } 
    }
}
