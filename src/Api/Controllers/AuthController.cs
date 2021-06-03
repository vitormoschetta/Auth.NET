using Api.Services;
using Domain.Commands;
using Domain.Contracts.Handlers;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {        
        private readonly IUserRepository _repository;
        private readonly IUserHandler _handler;
        private readonly TokenService _tokenService;
        private readonly EmailService _emailService;
        public AuthController(
            IUserRepository repository, 
            IUserHandler handler, 
            TokenService tokenService, 
            EmailService emailService)
        {
            _tokenService = tokenService;
            _repository = repository;
            _handler = handler;
            _emailService = emailService;
        }


        [HttpPost]
        public CommandResult Register(UserRegisterCommand command)
        {
            CommandResult result = _handler.Register(command);
            if (result.Success) {
                var user = (User)result.Data;
                _emailService.Send(user.Username, user.Email, user.EmailToken);  
                user.HideEmailToken(); 
                result.Data = user;
            }
                
            return result;
        }


        [HttpPost]
        public CommandResultToken Login(UserLoginCommand command)
        {
            CommandResultToken result = _handler.Login(command);
            if (result.Success)            
                 result.Token = _tokenService.GenerateToken((User)result.Data);        
          
            return result;
        }


        [HttpGet("{token}")]
        public ContentResult EmailValidate(string token)
        {
            CommandResult result = _handler.EmailValidate(token);
            return new ContentResult 
            {
                ContentType = "text/html",
                Content = $"<div style='text-align:center; margin-top:3em; color:#808080'><h1>{result.Message}</h1></div>"
            };            
        }


        [HttpGet("{email}")]
        public CommandResult ResetPassword(string email)
        {
            var user = new User();
            CommandResult result = _handler.ResetPassword(email); 
            if (result.Success) {
                user = (User)result.Data;
                _emailService.ResetPassword(user.Username, email, user.Password);  
                user.HidePassword();                 
            }
                
            return new CommandResult(result.Success, result.Message, user);       
        }
    }
}