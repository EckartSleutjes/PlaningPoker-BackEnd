using Microsoft.EntityFrameworkCore;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure
{
    public class PlaningPokerContext(DbContextOptions<PlaningPokerContext> options) : DbContext(options)
    {
        public DbSet<Room> Room { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Poker> Poker { get; set; }
        public DbSet<PokerItem> PokerItem { get; set; }
    }
}
