using task_manager_api.Entities;

namespace task_manager_api.Interfaces
{
    public interface IUserTaskService
    {
        Task<List<UserTask>> GetUserTasksAsync(Guid statusId, int pageNo, int pageSize);
    }
}
