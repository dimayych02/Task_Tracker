using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using UserTaskEnum;

namespace TaskTracker.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<UserTask>
    {
        public void Configure(EntityTypeBuilder<UserTask> builder)
        {
            builder.HasKey(t => t.TaskId);

            builder.Property(t => t.TaskName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.TaskDescription)
                .HasMaxLength(10000);

            builder.Property(t => t.TaskPriority)
                .IsRequired();

            builder.Property(t => t.TaskSeverity)
               .IsRequired();

            builder.Property(t => t.ReleaseVersion)
                .IsRequired();

            builder.Property(t => t.TaskStatus)
                .HasDefaultValue(TasksStatus.НОВАЯ);

            builder.Property(t => t.TimeEstimation)
                .HasDefaultValue(0.00);

        }
    }
}
