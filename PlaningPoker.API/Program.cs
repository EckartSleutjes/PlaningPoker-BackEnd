using Microsoft.EntityFrameworkCore;
using PlaningPoker.Infraestructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlaningPokerContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

var serviceScope = app.Services.CreateScope();
var context = serviceScope.ServiceProvider.GetRequiredService<PlaningPokerContext>();
context.Database.Migrate();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
