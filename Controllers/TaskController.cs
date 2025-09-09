using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_manager_api.Interfaces;

namespace task_manager_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTasksAsync([FromQuery] int statusId, int pageNo, int pageSize)
        {
            var tasks = await _taskService.GetTasksAsync(statusId, pageNo, pageSize);

            return Ok(tasks);
        }
    }
}
