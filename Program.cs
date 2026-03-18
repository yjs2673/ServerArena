using Microsoft.EntityFrameworkCore;
using MyGameServer.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. DB 연결 문자열
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. MySQL 서비스 등록 (Pomelo)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();