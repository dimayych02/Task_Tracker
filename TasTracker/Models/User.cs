using UserEnum;

namespace Models
{
    
    public  class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Profession Profession { get; set; }
        public string? UserEmail { get; set; }
        public virtual ICollection<UserRoles> Roles { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Executor> Executors { get; set; }
    }

}
