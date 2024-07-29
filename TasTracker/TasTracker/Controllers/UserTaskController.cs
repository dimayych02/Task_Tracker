using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;

namespace Controllers
{

    [Route("TaskTracker/[controller]")]
    [ApiController]
    public class UserTaskController : Controller
    {

        private readonly ITaskService _taskService;

        public UserTaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        public async Task<ActionResult<UserTask>> CreateUserTask(UserTask userTask)
        {
            var response = await _taskService.CreateTask(userTask);
           
            if (response.StatusCode == StatusCodeEnum.HttpStatusCode.CREATED)
                return Ok(response);

            return View("Error", response.Description);
        }

    }
}
