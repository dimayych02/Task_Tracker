using System.Diagnostics.Contracts;

namespace Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public int UserId { get; set; }
        public virtual User TaskAuthor { get; set; }
        public virtual ICollection<UserTask> AuthorTasks { get; set; }

    }
}
