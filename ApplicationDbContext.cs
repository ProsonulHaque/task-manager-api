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

            #region UserTask
            modelBuilder.Entity<UserTask>()
                .HasKey(x => x.UserTaskId);

            modelBuilder.Entity<UserTask>()
                .Property(x => x.UserTaskId)
                .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<UserTask>()
                .Property(x => x.CreateDate)
                .HasDefaultValueSql("NOW() at time zone 'utc'");
            #endregion

            #region Status
            modelBuilder.Entity<Status>()
                .HasKey(x => x.StatusId);

            modelBuilder.Entity<Status>()
                .Property(x => x.StatusId)
                .HasDefaultValueSql("uuid_generate_v4()");

            modelBuilder.Entity<Status>()
                .Property(x => x.CreateDate)
                .HasDefaultValueSql("NOW() at time zone 'utc'");
            #endregion
        }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
