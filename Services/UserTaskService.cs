using Microsoft.EntityFrameworkCore;
using task_manager_api.Entities;
using task_manager_api.Interfaces;

namespace task_manager_api.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly ApplicationDbContext _context;

        public UserTaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserTask>> GetUserTasksAsync(int statusId, int pageNo, int pageSize)
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
