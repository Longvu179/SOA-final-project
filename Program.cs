using Microsoft.EntityFrameworkCore;
using MyHotel;
using MyHotel.Email_Sender;
using MyHotel.Email_Sender.Email_Model;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyHotelDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MyHotelDbContextConnection' not found.");

builder.Services.AddDbContext<MyHotelDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
