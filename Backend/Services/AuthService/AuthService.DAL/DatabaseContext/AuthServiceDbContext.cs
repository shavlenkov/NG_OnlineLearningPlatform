using Microsoft.EntityFrameworkCore;
using AuthService.DAL.Entities;
using AuthService.DAL.Configurations;

namespace AuthService.DAL.DatabaseContext;

public class AuthServiceDbContext : DbContext
{
    public AuthServiceDbContext(DbContextOptions<AuthServiceDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}