using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace TaskTracker.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasKey(r => r.RoleId);

            builder.Property(r => r.UserRole)
                .IsRequired();

            builder
                .HasOne(r => r.UserRoles)
                .WithOne(uR => uR.Roles)
                .HasForeignKey<UserRoles>(uR => uR.RoleId);
        }
    }
}
