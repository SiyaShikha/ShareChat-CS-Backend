using Microsoft.EntityFrameworkCore;
using ShareChat.Data;
using ShareChat.Repositories;
using ShareChat.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChatDbContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.MapControllers();

app.Run();