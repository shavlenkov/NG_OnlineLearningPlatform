using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EnrollmentService.DAL.Entities;

namespace EnrollmentService.DAL.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.StudentId)
            .IsRequired();
        builder.Property(e => e.CourseId)
            .IsRequired();
        builder.Property(e => e.Progress)
            .IsRequired();
        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(e => e.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder.HasCheckConstraint("CK_Enrollment_Progress_Range", "[Progress] >= 0 AND [Progress] <= 100");
    }
}