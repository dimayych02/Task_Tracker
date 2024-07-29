using UserTaskEnum;

namespace Models
{
    

    public class UserTask
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public TasksStatus TaskStatus { get; set; } 
        public string? TaskDescription { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public TaskSeverity TaskSeverity { get; set; }
        public int? AuthorId { get; set; }
        public virtual Author? TaskAuthor { get; set; }
        public int? ExecutorId { get; set; }
        public virtual Executor? Executor { get; set; }
        public double TimeEstimation { get; set; }
        public DateOnly ReleaseVersion { get; set; }
        public DateOnly SprintStartTime { get; private set; }
        public DateOnly SprintEndTime { get; private set; }
        public DateTime LastTaskTimeModification { get; private set; }
    }
}
