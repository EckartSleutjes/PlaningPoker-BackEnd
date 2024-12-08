using PlaningPoker.Domain.Entity;

namespace PlaningPoker.Infraestructure
{
    public class Query
    {       
        public IQueryable<Poker> Pokers([Service] PlaningPokerContext context) =>
            context.Poker;
        public IQueryable<Room> Rooms([Service] PlaningPokerContext context) =>
            context.Room;
        public IQueryable<User> Users([Service] PlaningPokerContext context) =>
            context.User;
    } 
}
