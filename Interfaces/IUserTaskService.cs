using task_manager_api.Entities;

namespace task_manager_api.Interfaces
{
    public interface IUserTaskService
    {
        Task<List<UserTask>> GetUserTasksAsync(int statusId, int pageNo, int pageSize);
    }
}
