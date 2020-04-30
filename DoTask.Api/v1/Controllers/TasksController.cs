using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoTask.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TasksController : Controller
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //[HttpPost]
        //public Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskCommand createTaskCommand)
        //{
        //    var response = await _mediator.Send(command).ConfigureAwait(false);

        //    if (response.Errors.Any())
        //    {
        //        return BadRequest(response.Errors);
        //    }

        //    return Ok(response.Result);
        //}

        //[HttpPut("{id}")]
        //public void UpdateTaskAsync(int id, [FromBody] UpdateTaskCommand updateTaskCommand)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void DeleteTaskAsync(int id, [FromBody] DeleteTaskCommand deleteTaskCommand)
        //{
        //}
    }
}
