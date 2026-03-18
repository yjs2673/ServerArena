using Microsoft.EntityFrameworkCore;
using MyGameServer.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // 유저 테이블 (DB의 Users 테이블 매핑)
    public DbSet<User> Users { get; set; }
}