using Microsoft.EntityFrameworkCore;
using SpaceFleetAPI.Data;
using SpaceFleetAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpaceFleetDbContext>(options => options.UseSqlite("Data Source=SpaceFleetDB.db"));

builder.Services.AddControllers();

builder.Services.AddScoped<IPilotService,  PilotService>();
builder.Services.AddScoped<IShipService,  ShipService>();
builder.Services.AddScoped<IDestinationService,  DestinationService>();
builder.Services.AddScoped<IOrderService,  OrderService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SpaceFleetDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();