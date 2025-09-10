using Microsoft.EntityFrameworkCore;
using task_manager_api.Entities;
using task_manager_api.Interfaces;
using task_manager_api.Requests;

namespace task_manager_api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserTask>> GetTasksAsync(int statusId, int pageNo, int pageSize)
        {
            return await _context
                .UserTasks
                .Where(x => x.StatusId == statusId)
                .OrderBy(x => x.CreateDateUtc)
                .Skip(pageSize*(pageNo-1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<UserTask?> GetTaskByIdAsync(Guid id)
        {
            return await _context
                .UserTasks
                .Include(x => x.Status)
                .FirstOrDefaultAsync(x => x.UserTaskId == id);
        }

        public async Task<UserTask> CreateTaskAsync(CreateTaskCommand command)
        {
            var task = new UserTask
            {
                Title = command.Title,
                Description = command.Description,
                DueDate = command.DueDate,
                StatusId = command.StatusId
            };

            _context.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }
    }
}
