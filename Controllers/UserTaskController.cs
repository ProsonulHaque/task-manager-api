using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_manager_api.Interfaces;

namespace task_manager_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _userTaskService;

        public UserTaskController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTasksAsync([FromQuery] Guid status, int pageNo, int pageSize)
        {
            var tasks = await _userTaskService.GetUserTasksAsync(status, pageNo, pageSize);

            return Ok(tasks);
        }
    }
}
