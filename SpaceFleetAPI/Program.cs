using Microsoft.EntityFrameworkCore;
using SpaceFleetAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpaceFleetDbContext>(options => options.UseSqlite("Data Source=SpaceFleetDB.db"));

builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SpaceFleetDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();