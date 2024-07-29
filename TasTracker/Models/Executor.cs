
namespace Models
{
    public class Executor
    {
        public int ExecutorId { get; set; }
        public int UserId { get; set; }
        public virtual User TaskExecutor { get; set; }
        public virtual ICollection<UserTask> ExecutorTasks { get; set; }
    }
}
