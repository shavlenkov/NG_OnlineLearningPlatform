using Microsoft.EntityFrameworkCore;
using EnrollmentService.DAL.Entities;
using EnrollmentService.DAL.Configurations;

namespace EnrollmentService.DAL.DatabaseContext;

public class EnrollmentServiceDbContext : DbContext
{
    public EnrollmentServiceDbContext(DbContextOptions<EnrollmentServiceDbContext> options) : base(options)
    {
    }
    
    public DbSet<Enrollment> Enrollments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}