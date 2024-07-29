using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace TaskTracker.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.UserEmail)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(u => u.Roles)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder
                .HasMany(u => u.Authors)
                .WithOne(a => a.TaskAuthor)
                .HasForeignKey(a => a.UserId);

            builder
                .HasMany(u => u.Executors)
                .WithOne(e => e.TaskExecutor)
                .HasForeignKey(e => e.UserId);
        } 
    }
}
