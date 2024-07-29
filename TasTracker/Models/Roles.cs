using RoleEnum;

namespace Models
{
   
    public class Roles
    {
        public int RoleId { get; set; }
        public UserRole UserRole { get; set; }
        public virtual UserRoles UserRoles { get; set; }
    }
}
