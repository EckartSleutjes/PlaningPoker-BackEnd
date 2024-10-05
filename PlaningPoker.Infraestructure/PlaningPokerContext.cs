using Microsoft.EntityFrameworkCore;

namespace PlaningPoker.Infraestructure
{
    public class PlaningPokerContext : DbContext
    {
        public PlaningPokerContext(DbContextOptions<PlaningPokerContext> options) : base(options) { }


    }
}
