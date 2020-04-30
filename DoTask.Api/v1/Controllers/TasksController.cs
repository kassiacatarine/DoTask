using DoTask.Api.v1.Application.Commands.Tasks.CreateTaskCommand;
using DoTask.Api.v1.Application.Commands.Tasks.DeleteTaskCommand;
using DoTask.Api.v1.Application.Commands.Tasks.SetConcludeTaskCommand;
using DoTask.Api.v1.Application.Commands.Tasks.UpdateTaskCommand;
using DoTask.Api.v1.Application.Queries.Tasks.GetTaskDetailsQuery;
using DoTask.Api.v1.Application.Queries.Tasks.GetTaskDetailsQuery.ViewModels;
using DoTask.Api.v1.Application.Queries.Tasks.ListTaskSummaryQuery;
using DoTask.Api.v1.Application.Queries.Tasks.ListTaskSummaryQuery.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TasksController : ApiControllerBase
    {
        public TasksController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<TaskSummary[]>> GetTasksAsync()
        {
            return Single(await QueryAsync(new ListTaskSummaryQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetails>> GetTaskAsync(int id)
        {
            return Single(await QueryAsync(new GetTaskDetailsQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskCommand command)
        {
            var response = await CommandAsync(command);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(int id, [FromBody] UpdateTaskCommand command)
        {
            command.Id = id;
            var response = await CommandAsync(command);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(int id, [FromBody] DeleteTaskCommand command)
        {
            command.Id = id;
            var response = await CommandAsync(command);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPatch("{id}/conclude")]
        public async Task<IActionResult> ConcludeTaskAsync(int id, [FromBody] SetConcludeTaskCommand command)
        {
            command.Id = id;
            var response = await CommandAsync(command);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }
    }
}
