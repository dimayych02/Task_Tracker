namespace Models
{
    public class UserRoles
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int RoleId { get; set; }
        public virtual Roles Roles { get; set; }
        public DateTime LastTimeRoleChanged { get; private set; }
    }
}
