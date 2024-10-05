using Microsoft.EntityFrameworkCore;
using PlaningPoker.Domain.Entity;
using System.Data;

namespace PlaningPoker.Infraestructure
{
    public class PlaningPokerContext : DbContext
    {
        public PlaningPokerContext(DbContextOptions<PlaningPokerContext> options) : base(options) { }

        public DbSet<Room> Room { get; set; }
    }
}
