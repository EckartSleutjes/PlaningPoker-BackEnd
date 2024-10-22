namespace PlaningPoker.Domain.Dto
{
    public record CreateRoomResponseDto
    {
        public string TagRoom { get; set; } = null!;
        public Guid PlayerId { get; set; }

    }
}
