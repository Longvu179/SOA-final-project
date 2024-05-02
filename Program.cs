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
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithExposedHeaders("Content-Type");
                      });
});
builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
