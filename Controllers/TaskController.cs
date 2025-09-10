using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_manager_api.Interfaces;
using task_manager_api.Requests;

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

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand request)
        {
            var task = await _taskService.CreateTaskAsync(request);

            return CreatedAtAction(nameof(GetTaskById), new { id = task.UserTaskId }, task);
        }
    }
}
