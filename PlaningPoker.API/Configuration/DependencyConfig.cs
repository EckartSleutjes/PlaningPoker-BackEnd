using PlaningPoker.Application.Contract;
using PlaningPoker.Application.Service;
using PlaningPoker.Infraestructure.Repository;

namespace PlaningPoker.API.Configuration
{
    public static class DependencyConfig
    {
        public static void DependencyRegister(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IStorieRepository, StorieRepository>();
            services.AddScoped<IStorieService, StorieService>();
            services.AddScoped<IStoriePlayerRepository, StoriePlayerRepository>();
            services.AddScoped<IStoriePlayerService, StoriePlayerService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPokerService, PokerService>();
            services.AddScoped<IPokerRepository, PokerRepository>();
            services.AddSignalR();
        }
    }
}
