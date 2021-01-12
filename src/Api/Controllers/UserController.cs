using Domain.Commands;
using Domain.Contracts.Handlers;
using Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IUserHandler _handler;
        public UserController(IUserRepository repository, IUserHandler handler)         
        {         
            _repository = repository;
            _handler = handler;            
        }

        
        [HttpPost]
        [Authorize]
        public CommandResult UpdatePassword(UserUpdatePasswordCommand command)
        {
            CommandResult result = _handler.UpdatePassword(command, User.Identity.Name);
            return result;
        }
    }
}