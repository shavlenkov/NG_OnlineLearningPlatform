using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AuthService.DAL.Entities;

namespace AuthService.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(u => u.HashedPassword)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(u => u.AvatarURL)
            .HasMaxLength(255);
        builder.Property(u => u.Role)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50);
        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(u => u.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}