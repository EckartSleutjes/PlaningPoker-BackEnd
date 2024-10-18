using Microsoft.EntityFrameworkCore;
using PlaningPoker.API.Configuration;
using PlaningPoker.API.Hubs;
using PlaningPoker.Infraestructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.DependencyRegister();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlaningPokerContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

var serviceScope = app.Services.CreateScope();
var context = serviceScope.ServiceProvider.GetRequiredService<PlaningPokerContext>();
await context.Database.MigrateAsync();

app.MapHub<RoomHub>("/roomHub");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();
