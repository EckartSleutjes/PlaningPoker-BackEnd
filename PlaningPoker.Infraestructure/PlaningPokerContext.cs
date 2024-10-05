using Microsoft.EntityFrameworkCore;
using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure
{
    public class PlaningPokerContext : DbContext
    {
        public PlaningPokerContext(DbContextOptions<PlaningPokerContext> options) : base(options) { }

        public DbSet<Room> Room { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Poker> Poker { get; set; }
        public DbSet<PokerItem> PokerItem { get; set; }
    }
}
