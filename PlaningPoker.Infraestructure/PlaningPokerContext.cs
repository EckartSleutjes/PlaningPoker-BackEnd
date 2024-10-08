using Microsoft.EntityFrameworkCore;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure
{
    //dotnet ef migrations add {migrationName} --project .\PlaningPoker.Infraestructure\  --startup-project .\PlaningPoker.API\
    public class PlaningPokerContext(DbContextOptions<PlaningPokerContext> options) : DbContext(options)
    {
        public DbSet<Room> Room { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Poker> Poker { get; set; }
        public DbSet<PokerItem> PokerItem { get; set; }
        public DbSet<Storie> Storie { get; set; }
        public DbSet<StoriePlayer> StoriePlayer { get; set; }
    }
}
