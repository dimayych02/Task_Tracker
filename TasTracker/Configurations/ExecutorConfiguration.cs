using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace TaskTracker.Configurations
{
    public class ExecutorConfiguration : IEntityTypeConfiguration<Executor>
    {
        public void Configure(EntityTypeBuilder<Executor> builder)
        {
            builder.HasKey(e => e.ExecutorId);

            builder
                .HasMany(e => e.ExecutorTasks)
                .WithOne(t => t.Executor)
                .HasForeignKey(t => t.ExecutorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
