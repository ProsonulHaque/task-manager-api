using Microsoft.EntityFrameworkCore;
using task_manager_api.Entities;
using task_manager_api.Interfaces;

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
                .OrderBy(x => x.CreateDate)
                .Skip(pageSize*(pageNo-1))
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
