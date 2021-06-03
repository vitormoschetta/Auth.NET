using System.Collections.Generic;
using Domain.Commands;
using Domain.Contracts.Handlers;
using Domain.Queries.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Authorize]
        public CommandResult UpdatePassword([FromServices] IUserCommandHandler handler,
            [FromBody] UserUpdatePasswordCommand command)
        {
            return handler.UpdatePassword(command, User.Identity.Name);            
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<UserResponse> GetAll([FromServices] IUserQueryHandler handler)            
        {
            return handler.GetAll();            
        }
    }
}