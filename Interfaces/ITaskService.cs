using task_manager_api.Entities;

namespace task_manager_api.Interfaces
{
    public interface ITaskService
    {
        Task<List<UserTask>> GetTasksAsync(int statusId, int pageNo, int pageSize);
    }
}
