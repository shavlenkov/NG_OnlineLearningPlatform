using Microsoft.EntityFrameworkCore;
using CourseService.DAL.Entities;
using CourseService.DAL.Configurations;

namespace CourseService.DAL.DatabaseContext;

public class CourseServiceDbContext : DbContext
{
    public CourseServiceDbContext(DbContextOptions<CourseServiceDbContext> options) : base(options)
    {
    }
    
    public DbSet<Course> Courses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}