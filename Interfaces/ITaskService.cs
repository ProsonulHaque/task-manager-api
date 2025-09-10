using task_manager_api.Entities;
using task_manager_api.Requests;

namespace task_manager_api.Interfaces
{
    public interface ITaskService
    {
        Task<List<UserTask>> GetTasksAsync(int statusId, int pageNo, int pageSize);
        Task<UserTask?> GetTaskByIdAsync(Guid id);
        Task<UserTask> CreateTaskAsync(CreateTaskCommand command);
    }
}
