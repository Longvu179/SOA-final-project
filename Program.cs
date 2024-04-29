using Microsoft.EntityFrameworkCore;
using MyHotel;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyHotelDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MyHotelDbContextConnection' not found.");

builder.Services.AddDbContext<MyHotelDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
