using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace TaskTracker.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

            builder
                .HasMany(a => a.AuthorTasks)
                .WithOne(t => t.TaskAuthor)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
    
}
