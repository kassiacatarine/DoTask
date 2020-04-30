using DoTask.Api.v1.Application.Commands.Users.CreateUserCommand;
using DoTask.Api.v1.Application.Commands.Users.LoginCommand;
using DoTask.Api.v1.Application.Queries.Users.ListUserSummaryQuery;
using DoTask.Api.v1.Application.Queries.Users.UserSummaryQuery.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoTask.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserSummary>>> GetUsersAsync()
        {
            return Ok(await QueryAsync(new ListUserSummaryQuery()));
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="command">Info of user</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
        {

            var response = await CommandAsync(command);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginCommand command)
        {
            var response = await CommandAsync(command);

            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }
    }
}
