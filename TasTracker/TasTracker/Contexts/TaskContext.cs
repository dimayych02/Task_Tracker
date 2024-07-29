using Microsoft.EntityFrameworkCore;
using Models;
using TaskTracker.Configurations;

namespace Contexts
{
    public class TaskContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<UserTask> Tasks => Set<UserTask>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Executor> Executors => Set<Executor>();
        public DbSet<Roles> Roles => Set<Roles>();
        public DbSet<UserRoles> UserRoles => Set<UserRoles>();

        public TaskContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new  ConfigurationBuilder();

            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
                
            var config = builder.Build();

            var userName = config.GetConnectionString("userName");
            var password = config.GetConnectionString("password");
            var database = config.GetConnectionString("database");

            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql($"Host=localhost; Port=5432; Database={database}; Username={userName}; Password={password}");
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new ExecutorConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
