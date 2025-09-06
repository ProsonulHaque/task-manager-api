using Microsoft.EntityFrameworkCore;
using task_manager_api.Entities;

namespace task_manager_api
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<UserTask>()
                .HasKey(x => x.UserTaskId);

            modelBuilder.Entity<Status>()
                .HasKey(x => x.StatusId);
        }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
